using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IQueryable<Product> products = _context.Products.Where(p => !p.IsDeleted).Include(p => p.ProductImages).AsQueryable();
            ViewBag.ProductCount = products.Count();
            HomeVM home = new HomeVM { Sliders = _context.Sliders.OrderBy(s => s.Order), Brands = _context.Brands, FeaturedProducts = products.Take(4), LastestProducts = products.Take(4).OrderByDescending(p => p.Id) };
            return View(home);
        }
        [HttpPost]
        public IActionResult LoadProducts(int skip = 4, int take = 4)
        {
            return PartialView("_ProductPartial", _context.Products.Where(p => !p.IsDeleted).Include(p => p.ProductImages).Skip(skip).Take(take));
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Single_Product()
        {
            return View();
        }
    }
}
