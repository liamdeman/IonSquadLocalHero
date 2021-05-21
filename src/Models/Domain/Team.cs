using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Team
    {
        #region Properties

        public String Name { get; set; }
        public List<ApplicationUser> Members { get; set; }

        #endregion

        #region Constructors

        public Team()
        {
        }

        public Team(string name, ApplicationUser user)
        {
            this.Name = name;
            Members = new List<ApplicationUser> {user};
        }

        public Team(String name, List<ApplicationUser> users)
        {
            this.Name = name;
            Members = new List<ApplicationUser>(users);
        }

        #endregion
    }
}