using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Controllers
{
    public class PlayerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public PlayerController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        
        public async Task<IActionResult> Index(string searchString)
        {
            var users = from u in _userManager.Users
                         select u;

            if (!String.IsNullOrEmpty(searchString))
            { 
                users = users.Where(x => x.UserName.Contains(searchString) ||
                                         x.DiscordUserName.Contains(searchString) ||
                                         (x.DiscordUserName+"#"+x.DiscordDiscriminator)==searchString &&
                                         x.UserName != "admin")
                              .OrderBy(x => x.UserName)
                              .ThenBy(x =>x.DiscordUserName)
                              .ThenBy(x => x.DiscordDiscriminator);
            }

            return View(await users.ToListAsync());
        }
        public async Task<IActionResult> Detail(string id)
        {
            var user = _dbContext.Users
                .Include(a => a.GameProfiles)
                .ThenInclude(gp => gp.Game) //TODO: somehow doesn't include games
                .FirstOrDefault(u => u.UserName == id)/*.FindByNameAsync(id)*/;
            ViewData["IsAdmin"] = HttpContext.User.HasClaim(x => x.Value == "admin");
            ViewData["AccountType"] = (await _userManager.GetClaimsAsync(user)).FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            var playerViewModels = new PlayerViewModels.Detail(user, user.GameProfiles);
            return View(playerViewModels);
        }

        public async Task<IActionResult> GameProfiles()
        {
            var user = await _dbContext.Users.Include(x => x.GameProfiles)
                .FirstOrDefaultAsync(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var games = await _dbContext.Games.ToListAsync();
            Dictionary<string, string> profiles = new Dictionary<string, string>();
            List<Game> existingGames = new List<Game>();

            foreach (var profile in user.GameProfiles)
            {
                var game = profile.Game;
                profiles.Add(game.Name, profile.ProfileName);
                existingGames.Add(game);
            }

            foreach (var game in games.ToList().Except(existingGames))
            {
                profiles.Add(game.Name, "");
            }

            var gameProfilesViewModel = new GameProfilesViewModel();

            gameProfilesViewModel.Profiles = profiles;

            return View(gameProfilesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> GameProfiles(GameProfilesViewModel gamesViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["errorMessage"] = "één of meerdere waren niet correct ingevuld.";
                return View(gamesViewModel);
            }
            
            var user = await _dbContext.Users
                .Include(u => u.GameProfiles)
                .ThenInclude(gp => gp.Game)
                .SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);

            foreach ((var gameName, var userName) in gamesViewModel.Profiles.Where(p => p.Value is not null))
            {
                var game = _dbContext.Games.FirstOrDefault(g => g.Name == gameName);
                if (game is null)
                    return BadRequest();
                var existingProfile = user.GameProfiles.SingleOrDefault(gp => gp.Game.Name == game.Name);
                if (existingProfile is null)
                {
                    var profile = new GameProfile(userName, game);
                    user.GameProfiles.Add(profile);
                }
                else
                {
                    existingProfile.ProfileName = userName;
                }
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Detail), new { id = user.UserName });
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> ChangeAccountType(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRole =  claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (userRole.Value == "user")
            {
                await _userManager.RemoveClaimAsync(user, userRole);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                await _userManager.RemoveClaimAsync(user, userRole);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "user"));
            }
            return RedirectToAction("Index"); 
        }



    }
}
