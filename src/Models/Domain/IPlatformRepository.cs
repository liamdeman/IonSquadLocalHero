using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public interface IPlatformRepository
    {
        IEnumerable<Platform> GetAll();

        Platform GetBy(string name);
        IEnumerable<Platform> GetBy(IEnumerable<string> names);
    }
}
