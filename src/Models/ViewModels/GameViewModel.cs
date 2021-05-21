using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewModels
{
    public class GameViewModel
    {
        public class Detail
        {
            public string Name { get; }
            public string LoginService { get; set; }
            public string ToornamentAlias { get; set; }
            public ulong? DiscordIconId { get; set; } = null;

            public Detail()
            {
            }

            public Detail(Game game)
            {
                Name = game.Name;
                LoginService = game.LoginService.ToString();
                ToornamentAlias = game.ToornamentAlias;
                DiscordIconId = game.DiscordIconId;
            }
        }
    }
}