using BlogSite.Areas.Admin.ViewModels;
using BlogSite.Contexts;
using BlogSite.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
	{
        BlogContext _db { get; }

        public HomeController(BlogContext db)
        {
            _db = db;
        }
            public async Task<IActionResult> Index()
            {
                var items = await _db.Blogs.Select(s => new AdminBlogListItemVM
                {
                    Id = s.Id,
                    Image = s.Image,
                    Author = s.Author,
                    Header = s.Header,
                    CreatedDate = s.CreatedDate,
                    Description = s.Description
                }).ToListAsync();
                return View(items);
            }
	}
}
