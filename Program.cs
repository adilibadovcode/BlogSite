using BlogSite.Contexts;
using BlogSite.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BlogContext>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                 name: "areas",
                  pattern: "{area:exists}/{controller=Blog}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            PathConstants.RootPath = builder.Environment.WebRootPath;

            app.Run();
        }
    }
}