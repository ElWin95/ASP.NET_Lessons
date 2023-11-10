using FiorelloP416.DAL;
using FiorelloP416app.Entities;
using FiorelloP416app.Extension;
using FiorelloP416app.Helpers;
using FiorelloP416app.ModelViews.AdminCategory;
using FiorelloP416app.ModelViews.AdminProduct;
using FiorelloP416app.ModelViews.AdminSlider;
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
            var query = _context.Products.AsQueryable();
            var products = query.Include(p => p.Category)
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .Skip((page - 1) * take)
                .Take(4)
                .ToList();

            Pagination<Product> pagination = new Pagination<Product>(products, CalculatePage(query.Count(),take), page);

            return View(pagination);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var existProduct = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefault(s => s.Id == id);
            if (existProduct == null) return NotFound();
            return View(existProduct);
        }
        public int CalculatePage(int count, int take)
        {
            return (int)Math.Ceiling((decimal)(count) / take);
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
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existProduct = _context.Products.FirstOrDefault(c => c.Id == id);
            if (existProduct == null) return NotFound();
            var updateSliderVM = new UpdateProductVM { Id = existProduct.Id, Name = existProduct.Name, Price = existProduct.Price, Count = existProduct.Count };
            return View(updateSliderVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateProductVM updateProductVM)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            var existProduct = _context.Products.FirstOrDefault(c => c.Id == updateProductVM.Id);
            if (_context.Categories.Any(c => c.Name == updateProductVM.Name && c.Id != existProduct.Id))
            {
                ModelState.AddModelError("Name", "Artiq movcuddur...");
                return View();
            }
            foreach (var photo in updateProductVM.Photos)
            {
                if (!photo.CheckImage())
                {
                    ModelState.AddModelError("Photos", "Only image");
                    return View();
                }
                if (photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photos", "Oversize");
                    return View();
                }
                ProductImage productImage = new();
                if (photo == updateProductVM.Photos[0])
                {
                    productImage.IsMain = true;
                }
                productImage.ImageUrl = photo.SaveImage("img", _webHostEnvironment);
                existProduct.ProductImages.Add(productImage);
            }
            existProduct.Name = updateProductVM.Name;
            existProduct.Count = updateProductVM.Count;
            existProduct.Price = updateProductVM.Price;
            existProduct.CategoryId = updateProductVM.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
