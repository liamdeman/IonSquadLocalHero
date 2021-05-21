using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(string id);
    }
}