using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly ApplicationDbContext context;
        
        public PlatformRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Platform> GetAll()
        {
            return context.Platforms
                .AsNoTracking();
        }

        public Platform GetBy(string name)
        {
            return context.Platforms
                .FirstOrDefault(p => p.ShortName == name);
        }

        public IEnumerable<Platform> GetBy(IEnumerable<string> names)
        {
            return context.Platforms
                .Where(p => names.Contains(p.ShortName))
                .AsNoTracking();
        }
    }
}
