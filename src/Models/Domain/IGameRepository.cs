using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public interface IGameRepository
    {
        public IEnumerable<Game> GetAll();
        Game GetBy(string name);
        Game GetById(int id);
        Game Find(int id);
        void Update(Game game);
        Task AddAsync(Game game);
        void Remove(Game game);
        Task SaveChangesAsync();
        Task<bool> GameExists(int id);
    }
}