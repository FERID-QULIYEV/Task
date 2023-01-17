using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;

namespace Pronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandController:Controller
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()

        {
            return View(_context.Brands.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
