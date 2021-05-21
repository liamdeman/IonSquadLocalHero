using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewComponents
{
    public class BlogpostListViewComponent : ViewComponent
    {
        private readonly IBlogpostRepository _blogpostRepository;

        public BlogpostListViewComponent(IBlogpostRepository blogpostRepository)
        {
            _blogpostRepository = blogpostRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["IsAdmin"] = HttpContext.User.HasClaim(x => x.Value == "admin");

            if ((bool)ViewData["IsAdmin"])
            {
                return View(await _blogpostRepository.GetAllAsync());


            }
            else
            {
                return View(await _blogpostRepository.GetAllPublishedAsync());

            }
        }
    }
}