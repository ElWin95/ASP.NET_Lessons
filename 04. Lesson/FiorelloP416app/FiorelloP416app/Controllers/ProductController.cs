using FiorelloP416.DAL;
using FiorelloP416app.Entities;
using FiorelloP416app.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416app.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var products = _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Take(4)
                .ToList();
            return View(products);
        }
        public IActionResult LoadMore(int skip)
        {
            var products = _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Skip(skip)
                .Take(4)
                .ToList();

            return PartialView("_LoadMorePartial",products);
        }
        //public IActionResult LoadMore()
        //{
        //    var products = _appDbContext.Products
        //        .Select(p => new ProductVM
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            Category = p.Category,
        //        })
        //        .FirstOrDefault();

        //    return Json(products);
        //}
        //public IActionResult LoadMore()
        //{
        //    var products = _appDbContext.Products
        //        .Include(p => p.Category)
        //        .ToList();

        //    return Json(products);
        //}
    }
}
