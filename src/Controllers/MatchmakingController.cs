using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;
using Proj2Aalst_G3.Services.Matchmaking;

namespace Proj2Aalst_G3.Controllers
{
    public class MatchmakingController : Controller
    {
        private readonly MatchmakingService matchmakingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGameRepository gameRepository;

        public MatchmakingController(MatchmakingService matchmakingService,
            UserManager<ApplicationUser> userManager, IGameRepository gameRepository)
        {
            this.matchmakingService = matchmakingService;
            this.userManager = userManager;
            this.gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            ViewData["isUserInMatchmaking"] = IsCurrentUserInMatchmaking();
            return View(matchmakingService.GetAllUsers());
        }

        [Authorize]
        public IActionResult Subscribe()
        {
            if (IsCurrentUserInMatchmaking() is true)
                return BadRequest();
            return View(new MatchmakingViewModels.Subscribe(MatchmakingService.Games));
        }
        
        [HttpPost, ActionName("Subscribe")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult SubscribeConfirmed(MatchmakingViewModels.Subscribe viewModel)
        {
            if (IsCurrentUserInMatchmaking() is true)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var user = userManager.GetUserAsync(User).Result;
                var gamec = viewModel.Games
                    .Where(g => g.Selected);
                var games = gamec.Select(g => gameRepository.GetBy(g.Id));
                matchmakingService.AddUser(user.DiscordUserName, user.DiscordDiscriminator, null, 0, games.ToList());
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Unsubscribe()
        {
            if (IsCurrentUserInMatchmaking() is false)
                return BadRequest();
            var user = userManager.GetUserAsync(User).Result;
            matchmakingService.RemoveUser(user.DiscordUserName, user.DiscordDiscriminator);
            TempData["feedbackMessage"] = "Je bent niet meer in de matchmaker.";
            return RedirectToAction(nameof(Index));
        }

        private bool? IsCurrentUserInMatchmaking()
        {
            var user = userManager.GetUserAsync(User).Result;
            if (user is null)
                return null;
            return matchmakingService
                .GetAllUsers()
                .Any(u => u.Username == user.DiscordUserName && u.Discriminator == user.DiscordDiscriminator);
        }
    }
}
