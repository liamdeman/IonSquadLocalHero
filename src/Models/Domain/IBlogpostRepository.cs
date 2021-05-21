using Proj2Aalst_G3.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Data.Repositories
{
    public interface IBlogpostRepository
    {
        Task Add(Blogpost blogpost);
        Task<bool> BlogpostExists(int id);
        Task<Blogpost> FindAsync(int id);
        Task<List<Blogpost>> GetAllAsync();
        Task<List<Blogpost>> GetAllPublishedAsync();
        Task<Blogpost> GetByAsync(int id);
        void Remove(Blogpost blogpost);
        Task SaveChangesAsync();
        void Update(Blogpost blogpost);
    }
}