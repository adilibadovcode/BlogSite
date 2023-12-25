using BlogSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Contexts;

//public class BlogContext : IdentityDbContext
//{
//    private readonly DbContextOptions _options;

//    public BlogContext(DbContextOptions options) : base(options)
//    {
//        _options = options;
//    }

//    public DbSet<Blog> Blogs { get; set; }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//    }
//    //public BlogContext(DbContextOptions<BlogContext> opt) : base(opt) { }
//}

public class BlogContext : IdentityDbContext
{
    private readonly DbContextOptions _options;

    public BlogContext(DbContextOptions options) : base(options)
    {
        _options = options;
    }
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}
