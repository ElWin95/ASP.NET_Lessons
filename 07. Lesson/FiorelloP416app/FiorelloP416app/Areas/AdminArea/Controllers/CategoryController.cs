﻿using FiorelloP416.DAL;
using FiorelloP416app.ModelViews.AdminCategory;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Categories.ToList());
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var existCategory = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (existCategory == null) return NotFound();
            return View(existCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return Content($"{categoryCreateVM.Name} {categoryCreateVM.Desc}");
        }
    }
}
