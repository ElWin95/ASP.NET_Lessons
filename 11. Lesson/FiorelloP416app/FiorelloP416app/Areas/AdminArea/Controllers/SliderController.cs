﻿using FiorelloP416.DAL;
using FiorelloP416.Entities;
using FiorelloP416app.Extension;
using FiorelloP416app.ModelViews.AdminSlider;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
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
            if(!createSliderVM.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "Only image");
                return View();
            }
            if (createSliderVM.Photo.CheckImageSize(1000))
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }

            Slider slider = new();
            slider.ImageUrl = createSliderVM.Photo.SaveImage("img",_webHostEnvironment);
            _appDbContext.Sliders.Add(slider);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if(id == null) return NotFound();
            var existSlider = _appDbContext.Sliders.FirstOrDefault(s => s.Id == id);
            if (existSlider == null) return NotFound();
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", existSlider.ImageUrl);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _appDbContext.Sliders.Remove(existSlider);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
