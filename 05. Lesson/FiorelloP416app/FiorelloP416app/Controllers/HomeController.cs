using FiorelloP416.DAL;
using FiorelloP416app.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416app.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            HomeVM vm = new ();
            vm.Sliders = _appDbContext.Sliders.ToList();
            vm.SliderContent = _appDbContext.SliderContents.FirstOrDefault();
            vm.Categories = _appDbContext.Categories.ToList();
            vm.Products = _appDbContext.Products
                .Include(p=>p.ProductImages).ToList();
            return View(vm);
        }
    }
}
