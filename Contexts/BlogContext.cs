using BlogSite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Contexts;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> opt) : base(opt) { }
    public DbSet<Blog> Blogs { get; set; }
}
