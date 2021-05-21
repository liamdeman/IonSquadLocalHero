using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewModels
{
    public class PlayerViewModels
    {
        public class Detail 
        {
            public string UserName { get; set; }
            public string DiscordUserName { get; set; }
            public string DiscordDiscriminator { get; set; }
            public GameProfilesViewModel GameProfiles { get; set; }

            public Detail(ApplicationUser user, IEnumerable<GameProfile> profiles)
            {
                UserName = user.UserName;
                DiscordUserName = user.DiscordUserName;
                DiscordDiscriminator = user.DiscordDiscriminator;
                GameProfiles = new GameProfilesViewModel();

                foreach (var profile in profiles)
                {
                    GameProfiles.Profiles.Add(profile.Game.Name, profile.ProfileName);
                }
            }
        }

    }
}
