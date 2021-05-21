using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewComponents
{
    public class TournamentListViewComponent : ViewComponent
    {
        private readonly ITournamentRepository tournamentRepository;
        
        public TournamentListViewComponent(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int startRange = 0, int endRange = 4)
        {
            var tournaments = await tournamentRepository.GetRange(startRange, endRange);
            return View(tournaments);
        }
    }
}
