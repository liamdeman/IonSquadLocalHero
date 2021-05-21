using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Platform
    {
        public string ShortName { get; }
        public string FullName { get; }

        public Platform()
        {
        }

        public Platform(string shortName, string fullName)
        {
            ShortName = shortName;
            FullName = fullName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Platform other)
            {
                if (ShortName == other.ShortName)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ShortName.GetHashCode();
        }
    }
}
