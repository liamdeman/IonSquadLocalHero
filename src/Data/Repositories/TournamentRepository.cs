using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;
using Proj2Aalst_G3.Services.Toornament;

namespace Proj2Aalst_G3.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IToornamentService toornamentService;

        private static DateTime lastTournamentListRefresh;

        public TournamentRepository(ApplicationDbContext context,
            IToornamentService toornamentService)
        {
            this.context = context;
            this.toornamentService = toornamentService;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync(bool forceFetch = false)
        {
            var timeSinceLastRefresh = DateTime.Now.Subtract(lastTournamentListRefresh);
            if (forceFetch || timeSinceLastRefresh.Minutes > 1)
            {
                var tournamentList = await toornamentService.GetTournaments(0, 49);
                await UpdateAndAdd(tournamentList);
                await SaveChangesAsync();
                lastTournamentListRefresh = DateTime.Now;
            }
            return context.Tournaments
                .Include(t => t.Logo)
                .AsNoTracking();
        }

        public async Task<IEnumerable<Tournament>> GetRange(int startRange, int endRange)
        {
            var tournaments = (await GetAllAsync()).ToList();
            if (endRange - startRange > tournaments.Count)
                return tournaments;
            else
                return tournaments
                    .GetRange(startRange, endRange - startRange);
        }

        public async Task<IEnumerable<Tournament>> GetAtDate(DateTime date)
        {
            var tournaments = await GetAllAsync();
            return tournaments.Where(x => x.RegistrationClosingDatetime.HasValue && x.RegistrationClosingDatetime.Value.Date == date.Date).ToList();

        }

        public async Task<Tournament> GetBy(string id, bool forceFetch = false)
        {
            var trackedTournament = context.Tournaments
                .Include(t => t.Logo)
                .FirstOrDefault(t => t.Id == id);
            if (trackedTournament == null)
            {
                throw new ArgumentException("Tournament is not tracked.");
            }

            if (trackedTournament.ParticipantType == null
                || DateTime.Now.Subtract(trackedTournament.LastUpdated.GetValueOrDefault()).Minutes > 1)
            {
                var refreshedTournament = await toornamentService.GetTournamentDetails(id);
                trackedTournament.Update(refreshedTournament);
                await SaveChangesAsync();
            }

            return trackedTournament;
        }

        public async Task<string> UpdateAsync(TournamentViewModels.Edit viewModel)
        {
            Tournament tournamentUpdated;
            if (viewModel.Id is not null)
            {
                tournamentUpdated =
                    await toornamentService.UpdateTournament(viewModel.Id,
                        new Queries.Tournament.Update(viewModel));
                var tournament = await GetBy(tournamentUpdated.Id);
                tournament.Update(tournamentUpdated);
                context.Tournaments.Update(tournament);
            }
            else
            {
                tournamentUpdated =
                    await toornamentService.CreateTournament(new Queries.Tournament.Create(viewModel));
                await context.Tournaments.AddAsync(tournamentUpdated);
            }
            await context.SaveChangesAsync();
            return tournamentUpdated.Id;
        }

        public async Task<Registration> RegisterAsync(string id, RegistrationViewModels.Create viewModel)
        {
            var registration = await toornamentService.CreateRegistration(id, new Queries.Registration(viewModel));
            await context.Registrations.AddAsync(registration);
            return registration;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync(int startIndex = 0, int endIndex = 49, Services.Toornament.Filters.RegistrationFilter filter = null)
        {
            return await context.Registrations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task RemoveAsync(Tournament tournament)
        {
            await toornamentService.DeleteTournament(tournament.Id);
            context.Tournaments.Remove(tournament);
            await SaveChangesAsync();
        }

        public void SaveChanges() => context.SaveChanges();

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        private async Task UpdateAndAdd(IEnumerable<Tournament> tournaments)
        {
            tournaments = tournaments.ToList();
            
            var existingTournaments = context.Tournaments
                .ToList()
                .Where(t => tournaments.Any(tr => tr.Id == t.Id))
                .ToList();

            foreach (var tournament in tournaments)
            {
                var existingTournament = existingTournaments
                    .FirstOrDefault(t => t.Id == tournament.Id);
                if (existingTournament == null)
                    await context.Tournaments.AddAsync(tournament);
                else
                {
                    existingTournament.Update(tournament);
                    context.Tournaments.Update(existingTournament);
                }
                await SaveChangesAsync();
            }
        }
    }
}