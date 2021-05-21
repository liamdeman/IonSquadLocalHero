using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        #region Properties
        public string DiscordUserName { get; set; }
        public string DiscordDiscriminator { get; set; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public ICollection<Tournament> Tournaments { get; set; }
        public ICollection<GameProfile> GameProfiles { get; set; } = new List<GameProfile>();
        #endregion

        #region Constructors
        public ApplicationUser()
        {

        }

        public ApplicationUser(string userName, string email)
        {
            this.UserName = userName;
            this.Email = email;
        }

        public ApplicationUser(string userName, string email, string discordUsername, string discordDiscriminator) : this(userName, email)
        {
            this.DiscordUserName = discordUsername;
            this.DiscordDiscriminator = discordDiscriminator;
        }

        #endregion

        #region Methods
        public void AddGameProfile(string profileName, Game game)
        {
            GameProfiles.Add(new GameProfile(profileName, game));
        }
        #endregion


    }
}