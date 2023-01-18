using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModels;

namespace Pronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController: Controller
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBrandVM brandVm)
        {

            if (!ModelState.IsValid) return View();
            IFormFile file = brandVm.ImageFile;
            if (!file.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Duzgun sekil yukle");
                return View();
            }
            if (!(brandVm.ImageFile.Length / 1024 / 1024 < 2))
            {
                ModelState.AddModelError("Image", "Sekilin hecmi 2mb-dan cox olmaz");
                return View();
            }
            string fileName = Guid.NewGuid() + file.FileName;
            using (var stream = new FileStream(Path.Combine(_env.WebRootPath, "assets", "images", "brand", fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Brand brand = new Brand { ImageUrl = fileName };
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
