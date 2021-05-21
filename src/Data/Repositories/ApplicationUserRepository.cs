using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ApplicationUser> _users;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
            _users = context.Users;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _users.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}