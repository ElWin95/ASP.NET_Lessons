using FiorelloP416.DAL;
using FiorelloP416app.Entities;
using FiorelloP416app.Extension;
using FiorelloP416app.Helpers;
using FiorelloP416app.ModelViews.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416app.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int page=1, int take=4)
        {
            var products = _context.Products
                .Include(p=>p.Category)
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .Skip((page-1)*take)
                .Take(4)
                .ToList();
            var count = _context.Products.Count();
            var pageCount = (int)Math.Ceiling((decimal)(count) / take);

            Pagination<Product> pagination = new Pagination<Product>(products, pageCount, page);

            return View(pagination);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateProductVM createProduct)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if(!ModelState.IsValid) return View();
            Product newProduct = new();
            newProduct.Name = createProduct.Name;
            newProduct.Count = createProduct.Count;
            newProduct.Price = createProduct.Price;
            newProduct.CategoryId = createProduct.CategoryId;
            newProduct.ProductImages = new();
            foreach (var photo in createProduct.Photos)
            {
                if (!photo.CheckImage())
                {
                    ModelState.AddModelError("Photos", "Only image");
                    return View();
                }
                if(photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photos", "Oversize");
                    return View();
                }
                ProductImage productImage = new();
                if(photo == createProduct.Photos[0])
                {
                    productImage.IsMain = true;
                }
                productImage.ImageUrl = photo.SaveImage("img",_webHostEnvironment);
                newProduct.ProductImages.Add(productImage);
            }
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
