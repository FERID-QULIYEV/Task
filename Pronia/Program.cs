using Microsoft.EntityFrameworkCore;
using Pronia.DAL;

namespace Pronia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "Login", pattern: "Login", defaults: new { Controller = "Home", Action = "Login" });
            app.MapControllerRoute(name: "Cart", pattern: "Cart", defaults: new { Controller = "Home", Action = "Cart" });
            app.MapControllerRoute(name: "Index", pattern: "Index", defaults: new { Controller = "Home", Action = "Index" });
            app.MapControllerRoute(name: "Index_2", pattern: "Index_2", defaults: new { Controller = "Home", Action = "Index_2" });
            app.MapControllerRoute(name: "Shop", pattern: "Shop", defaults: new { Controller = "Home", Action = "Shop" });
            app.MapControllerRoute(name: "Single_Product", pattern: "Single_Product", defaults: new { Controller = "Home", Action = "Single_Product" });
            app.Run();
        }
    }
}