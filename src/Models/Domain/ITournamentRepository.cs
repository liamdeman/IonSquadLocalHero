using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Editing;
using Proj2Aalst_G3.Models.ViewModels;

namespace Proj2Aalst_G3.Models.Domain
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAllAsync(bool forceFetch = false);
        Task<IEnumerable<Tournament>> GetRange(int startRange, int endRange);
        Task<IEnumerable<Tournament>> GetAtDate(DateTime date);

        Task<Tournament> GetBy(string id, bool forceFetch = false);
        Task<string> UpdateAsync(TournamentViewModels.Edit viewModel);
        Task RemoveAsync(Tournament tournament);
        
        Task<Registration> RegisterAsync(string id, RegistrationViewModels.Create viewModel);

        Task<IEnumerable<Registration>> GetAllRegistrationsAsync(int startIndex = 0, int endIndex = 49,
            Services.Toornament.Filters.RegistrationFilter filter = null);
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}