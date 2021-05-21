using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Game
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; private set; }
        public LoginService LoginService { get; set; }
        public string ToornamentAlias { get; set; }
        public ulong? DiscordIconId { get; set; } = null;
        #endregion
        
        #region Constructors

        public Game()
        {
        }

        public Game(string name, LoginService service)
        {
            Name = name;
            LoginService = service;
            ToornamentAlias = name.ToLower().Replace(" ", "");
        }

        public Game(string name, LoginService service, string toornamentAlias)
        {
            Name = name;
            LoginService = service;
            ToornamentAlias = toornamentAlias;
        }

        #endregion

        //public override bool Equals(object? obj)
        //{
        //    if (obj is Game other)
        //    {
        //        if (Name == other.Name)
        //            return true;
        //    }

        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}