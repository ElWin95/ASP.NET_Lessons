using FiorelloP416.DAL;
using FiorelloP416app.Entities;
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
            return View(_appDbContext.Categories.Where(c=>!c.isDeleted).ToList());
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
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Categories.Any(c=>c.Name.ToLower()==categoryCreateVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Bu adli category movcuddur...");
                return View();
            }
            Category category = new();
            category.Name = categoryCreateVM.Name;
            category.Desc = categoryCreateVM.Desc;
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id==null) return NotFound();
            var existCategory = _appDbContext.Categories.FirstOrDefault(c=>c.Id==id);
            if (existCategory == null) return NotFound();
            var updateCategoryVM = new UpdateCategoryVM {Id=existCategory.Id, Name = existCategory.Name, Desc = existCategory.Desc };
            return View(updateCategoryVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateCategoryVM updateCategoryVM)
        {
            if (!ModelState.IsValid) return View();
            var existCategory = _appDbContext.Categories.FirstOrDefault(c => c.Id == updateCategoryVM.Id);

            if (_appDbContext.Categories.Any(c=>c.Name == updateCategoryVM.Name && c.Id!=existCategory.Id))
            {
                ModelState.AddModelError("Name", "Artiq movcuddur...");
                return View();
            }

            existCategory.Name = updateCategoryVM.Name;
            existCategory.Desc = updateCategoryVM.Desc;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound(); 
            var deletedCategory = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (deletedCategory == null) return NotFound();
            deletedCategory.isDeleted = true;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
