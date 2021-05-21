using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewModels
{
    public class MatchmakingViewModels
    {
        public class Subscribe
        {
            public List<GameCheckbox> Games { get; init; } = new();

            public Subscribe(IEnumerable<Game> games)
            {
                foreach (var game in games)
                    Games.Add(new GameCheckbox(game));
            }

            public Subscribe()
            {
                
            }
        }

        public class GameCheckbox
        {
            public string Name { get; init; }
            public string Id { get; init; }
            public bool Selected { get; init; } = false;

            public GameCheckbox(Game game)
            {
                Name = game.Name;
                Id = game.ToornamentAlias;
            }

            public GameCheckbox()
            {
                
            }
        }
    }
}
