using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }
        
        public Game GetBy(string name)
        {
            return _context.Games.FirstOrDefault(x => x.ToornamentAlias == name);
        }
        
        public Game GetById(int id)
        {
            return _context.Games.FirstOrDefault(m => m.Id == id);
        }
        
        public Game Find(int id)
        {
            return _context.Games.Find(id);
        }
        
        public void Update(Game game)
        {
            _context.Update(game);
        }

        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
        }

        public void Remove(Game game)
        {
            _context.Games.Remove(game);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        
        public async Task<bool> GameExists(int id)
        {
            return await _context.Games.AnyAsync(e => e.Id == id);
        }

    }
}