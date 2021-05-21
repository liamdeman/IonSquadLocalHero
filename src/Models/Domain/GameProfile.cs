using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class GameProfile
    {
        #region Properties

        public int Id { get; set; }
        public Game Game { get; set; }
        public string ProfileName { get; set; }

        #endregion

        #region Constructrs

        public GameProfile()
        {
        }

        public GameProfile(string profileName, Game game)
        {
            ProfileName = profileName;
            Game = game;
        }

        #endregion
    }
}