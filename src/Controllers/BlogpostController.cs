using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Models.Domain;
using static AspNet.Security.OAuth.Discord.DiscordAuthenticationConstants;

namespace Proj2Aalst_G3.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class BlogpostController : Controller
    {
        private readonly IBlogpostRepository _blogpostRepository;

        public BlogpostController(IBlogpostRepository blogpostRepository)
        {
            _blogpostRepository = blogpostRepository;
        }

        // GET: Blogpost
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Blogpost/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _blogpostRepository.GetByAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            ViewData["IsAdmin"] = HttpContext.User.HasClaim(x => x.Value == "admin");
            return View(blogpost);
        }

        // GET: Blogpost/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogpost/Create
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PublicationTime,Text")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                _blogpostRepository.Add(blogpost);
                await _blogpostRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogpost);
        }

        // GET: Blogpost/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _blogpostRepository.FindAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            return View(blogpost);
        }

        // POST: Blogpost/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PublicationTime,Text")] Blogpost blogpost)
        {
            if (id != blogpost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _blogpostRepository.Update(blogpost);
                    await _blogpostRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _blogpostRepository.BlogpostExists(blogpost.Id)))
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
            return View(blogpost);
        }

        // GET: Blogpost/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _blogpostRepository.GetByAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }

            return View(blogpost);
        }

        // POST: Blogpost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogpost = await _blogpostRepository.FindAsync(id);
            _blogpostRepository.Remove(blogpost);
            await _blogpostRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
