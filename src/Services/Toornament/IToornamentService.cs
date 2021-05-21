using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Services.Toornament
{
    public interface IToornamentService
    {
        Task<IEnumerable<Tournament>> GetTournaments(
            int startRange,
            int endRange,
            Filters.TournamentFilter filter = null);
        Task<Tournament> GetTournamentDetails(string id);
        Task<Tournament> UpdateTournament(string id, Queries.Tournament.Update tournament);
        Task<Tournament> CreateTournament(Queries.Tournament.Create tournament);
        Task<HttpStatusCode> DeleteTournament(string id);

        Task<IEnumerable<Registration>> GetRegistrations(
            Filters.RegistrationFilter filter,
            int startIndex = 0, int endIndex = 49);
        Task<Registration> CreateRegistration(string id, Queries.Registration registrationDto);
    }
}