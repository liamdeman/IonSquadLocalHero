using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NodaTime;
using NodaTime.Extensions;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;
using Proj2Aalst_G3.Services.Toornament;

namespace Proj2Aalst_G3.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly ILogger<TournamentsController> logger;
        private readonly ITournamentRepository tournamentRepository;
        private readonly IPlatformRepository platformRepository;
        private readonly IGameRepository gameRepository;

        public TournamentsController(
            ILogger<TournamentsController> logger,
            ITournamentRepository tournamentRepository,
            IPlatformRepository platformRepository,
            IGameRepository gameRepository)
        {
            this.logger = logger;
            this.tournamentRepository = tournamentRepository;
            this.platformRepository = platformRepository;
            this.gameRepository = gameRepository;
        }

        //TODO add filtering, mostly range parameter. perhaps something with scrollable pages?
        public IActionResult Index()
        {
            return View(); //Todo uncomment in prod
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await tournamentRepository.GetBy(id);
            if (tournament == null)
            {
                return NotFound();
            }

            var registrations = await tournamentRepository.GetAllRegistrationsAsync();
            
            return View(new TournamentViewModels.Detail(tournament, registrations?.Where(r => r.TournamentId == tournament.Id)));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            
            if (id == null)
            {
                ViewData["isEdit"] = false;
                ViewData["platforms"] = GetPlatformsAsMultiSelectList();
                ViewData["participantTypes"] = GetParticipantTypesAsSelectList();
                ViewData["timezones"] = GetTimezonesAsSelectList();
                ViewData["games"] = GetGamesAsSelectList();
                return View(new TournamentViewModels.Edit());
            }

            var tournament = await tournamentRepository.GetBy(id);
            if (tournament == null)
            {
                return NotFound();
            }

            ViewData["isEdit"] = true;
            //ViewData["platforms"] = GetPlatformsAsMultiSelectList(tournament.Platforms.Select(p => platformRepository.GetBy(p)));
            ViewData["timezones"] = GetTimezonesAsSelectList(tournament.Timezone);
            return View(nameof(Edit), new TournamentViewModels.Edit(tournament));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id, TournamentViewModels.Edit viewModel)
        {
            if (id is not null && id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (viewModel.ParticipantType == "single")
                {
                    viewModel.TeamMinSize = null;
                    viewModel.TeamMaxSize = null;
                }

                if (!viewModel.RegistrationEnabled)
                {
                    viewModel.RegistrationOpeningDatetime = null;
                    viewModel.RegistrationClosingDatetime = null;
                }

                if (!viewModel.CheckInParticipantEnabled)
                {
                    viewModel.CheckInParticipantStartDatetime = null;
                    viewModel.CheckInParticipantEndDatetime = null;
                }
                
                try
                {
                    id = await tournamentRepository.UpdateAsync(viewModel);
                    await tournamentRepository.SaveChangesAsync();
                }
                catch (BadHttpRequestException e)
                {
                    TempData["refreshMessage"] = $"{e.Message}, Status Code: {e.StatusCode}";
                }
                
                return RedirectToAction(nameof(Details), new { id });
            }
            
            if (!ModelState.IsValid && viewModel.Id is null)
            {
                ViewData["isEdit"] = false;
            }
            
            ViewData["platforms"] = GetPlatformsAsMultiSelectList();
            ViewData["participantTypes"] = GetParticipantTypesAsSelectList();
            ViewData["timezones"] = GetTimezonesAsSelectList();
            ViewData["games"] = GetGamesAsSelectList(viewModel.Discipline);

            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await tournamentRepository.GetBy(id);
            if (tournament == null)
            {
                return NotFound();
            }

            ViewData["tournamentName"] = tournament.Name;
            ViewData["tournamentId"] = id;

            return View();
        }
        
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tournament = await tournamentRepository.GetBy(id);
            await tournamentRepository.RemoveAsync(tournament);
            await tournamentRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Register(string id, [FromServices] UserManager<ApplicationUser> userManager)
        {
            ViewData["tournamentId"] = id;
            ViewData["isPosted"] = false;
            ViewData["isSingle"] = false;

            var tournament = await tournamentRepository.GetBy(id);
            if (tournament.ParticipantType == "single")
            {
                ViewData["isSingle"] = true;
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var model = new RegistrationViewModels.Create()
                {
                    CustomFields = null,
                    CustomUserIdentifier = user.Id,
                    Email = user.Email,
                    Lineup = null,
                    Name = user.UserName,
                    Type = "player"
                };
                return View(model);
            }
            
            return View(new RegistrationViewModels.Create());
        }
        
        [HttpPost, ActionName(nameof(Register))]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> RegisterConfirmed(string id, RegistrationViewModels.Create viewModel)
        {
            ViewData["isPosted"] = true;
            var registration = await tournamentRepository.RegisterAsync(id, viewModel);

            return View(new RegistrationViewModels.Create(registration)); // replace with viewmodel later
        }

        private bool TournamentExists(string id)
        {
            return tournamentRepository.GetBy(id) != null;
        }

        private MultiSelectList GetPlatformsAsMultiSelectList(IEnumerable<Platform> selected = null)
        {
            return new MultiSelectList(
                platformRepository.GetAll().OrderBy(c => c.FullName),
                nameof(Platform.ShortName), nameof(Platform.FullName), selected);
        }

        private SelectList GetParticipantTypesAsSelectList(string selected = null)
        {
            return new SelectList(new []
            {
                "team",
                "single"
            }, selected);
        }

        private SelectList GetTimezonesAsSelectList(string selected = "Europe/Brussels")
        {
            var provider = DateTimeZoneProviders.Tzdb;
            return new SelectList(provider.GetAllZones(),nameof(DateTimeZone.Id), nameof(DateTimeZone.Id), selected);
        }

        private SelectList GetGamesAsSelectList(string selected = null)
        {
            return new SelectList(gameRepository.GetAll(),
                nameof(Game.ToornamentAlias),
                nameof(Game.Name),
                selected);
        }
    }
}