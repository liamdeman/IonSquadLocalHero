using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Logo
    {
        public int Id { get; set; }

        public string LogoSmall { get; set; }

        public string LogoMedium { get; set; }

        public string LogoLarge { get; set; }

        public string Original { get; set; }

        public Logo()
        {
        }
    }
}