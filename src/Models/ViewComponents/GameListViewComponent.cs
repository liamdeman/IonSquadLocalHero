using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewComponents
{
    public class GameListViewComponent : ViewComponent
    {
        private readonly IGameRepository gameRepository;
        
        public GameListViewComponent(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var games = gameRepository.GetAll();
            return View(games);
        }
    }
}