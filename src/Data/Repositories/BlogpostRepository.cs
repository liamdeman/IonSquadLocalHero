using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Data.Repositories
{
    public class BlogpostRepository : IBlogpostRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Blogpost> _blogposts;

        public BlogpostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _blogposts = dbContext.Blogposts;
        }
        public async Task Add(Blogpost blogpost)
        {
            await _blogposts.AddAsync(blogpost);
        }

        public void Remove(Blogpost blogpost)
        {
            _blogposts.Remove(blogpost);
        }


        public async Task<List<Blogpost>> GetAllAsync()
        {
            return await _blogposts.OrderBy(x => x.PublicationTime).Reverse().ToListAsync();
        }

        public async Task<List<Blogpost>> GetAllPublishedAsync()
        {
            return await _blogposts.Where(x => x.PublicationTime <= DateTime.Now).OrderBy(x => x.PublicationTime).Reverse().ToListAsync();
        }


        public async Task<Blogpost> GetByAsync(int id)
        {
            return  await _blogposts.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Blogpost> FindAsync(int id)
        {
            return await _blogposts.FindAsync(id);
        }


        public async Task SaveChangesAsync()
        {

            await _dbContext.SaveChangesAsync();

        }


        public void Update(Blogpost blogpost)
        {
            _dbContext.Update(blogpost);
        }

        public async Task<bool> BlogpostExists(int id)
        {
            return await _blogposts.AnyAsync(e => e.Id == id);
        }
    }
}
