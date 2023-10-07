using FiorelloP416.DAL;
using FiorelloP416.Entities;
using FiorelloP416app.ModelViews.AdminSlider;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SliderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSliderVM createSliderVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bosh qoyma");
                return View();
            }
            if(!createSliderVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Only image");
                return View();
            }
            if (createSliderVM.Photo.Length>1000)
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }
            Slider slider = new();
            slider.ImageUrl = "";
            _appDbContext.Sliders.Add(slider);
            _appDbContext.SaveChanges();
            return View();
        }
    }
}
