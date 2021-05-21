using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;

namespace Proj2Aalst_G3.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            this._gameRepository = gameRepository;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public IActionResult Games()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Detail(int id)
        {
            var game = _gameRepository.GetById(id);
            
            if (game == null)
                return NotFound();
            
            return View(game);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,LoginService,ToornamentAlias,DiscordIconId")] Game game)
        {
            if (ModelState.IsValid)
            {
                await _gameRepository.AddAsync(game);
                await _gameRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(game);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
                return NotFound();

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LoginService,ToornamentAlias,DiscordIconId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _gameRepository.Update(game);
                    await _gameRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _gameRepository.GameExists(game.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        
        
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }
    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = _gameRepository.Find(id);
            _gameRepository.Remove(game);
            await _gameRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}