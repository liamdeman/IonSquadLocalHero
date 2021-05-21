using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewModels
{
    public class RegistrationViewModels
    {
        
        public class Create
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string CustomUserIdentifier { get; set; }
            public Dictionary<string, string> CustomFields { get; set; }
            public string Type { get; set; }
            public List<LineupCreate> Lineup { get; set; }

            public Create(Registration reg)
            {
                Name = reg.Name;
                Email = reg.Email;
                CustomUserIdentifier = reg.CustomUserIdentifier;
                CustomFields = reg.CustomFields;
                Type = reg.Type;
                Lineup = reg.Lineup?
                    .Select(l => new LineupCreate(l))
                    .ToList();
            }

            public Create()
            {
            }


            public class LineupCreate
            {
                public string Name { get; set; }
                public string Email { get; set; }
                public string CustomUserIdentifier { get; set; }
                public Dictionary<string, string> CustomFields { get; set; }

                public LineupCreate(Lineup lineup)
                {
                    Name = lineup.Name;
                    Email = lineup.Email;
                    CustomUserIdentifier = lineup.CustomUserIdentifier;
                    CustomFields = lineup.CustomFields;
                }

                public LineupCreate()
                {
                }
            }
        }
    }
}
