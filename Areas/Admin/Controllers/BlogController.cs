using BlogSite.Contexts;
using BlogSite.Helpers;
using BlogSite.Models;
using BlogSite.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogContext _db { get; }
        IWebHostEnvironment _env { get; }

        public BlogController(BlogContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        //Index
        public async Task<IActionResult> Index()
        {
            var items = await _db.Blogs.Select(s => new BlogListItemVM
            {
                Id = s.Id,
                Image = s.Image,
                Header = s.Header,
                Author = s.Author,
                Description = s.Description,
                CreatedDate = s.CreatedDate
            }).ToListAsync();
            return View(items);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVM vm)
        {
            Blog blog = new Blog
            {
                Id = vm.Id,
                Image =await vm.Image.SaveAsync(PathConstants.Blog),
                Header = vm.Header,
                Author = vm.Author,
                CreatedDate = DateTime.Now,
                Description = vm.Description
            };
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Delete
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return BadRequest();
            var data = await _db.Blogs.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Blogs.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Update
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null || Id <= 0) return BadRequest();
            var data = await _db.Blogs.FindAsync(Id);
            if (data == null) return NotFound();
            string path = Path.Combine("blog", "products");

            var vm = new BlogUpdateVM
            {
                Id = data.Id,
                //Image = await data.Image.SaveAsync(PathConstants.Blog),
                Header = data.Header,
                Author = data.Author,
                CreatedDate = data.CreatedDate,
                Description = data.Description,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateVM vm, int? Id)
        {
            var data = await _db.Blogs.FindAsync(Id);
            string path = Path.Combine("blog", "products");
            if (data != null)
            {
                data.Id = vm.Id;
                data.Image = await vm.Image.SaveAsync(path);
                data.Header = vm.Header;
                data.Author = vm.Author;
                data.CreatedDate = DateTime.Now;
                data.Description = vm.Description;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View();
        }
    }
}
