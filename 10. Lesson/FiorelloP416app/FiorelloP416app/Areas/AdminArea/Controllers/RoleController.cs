using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) return NotFound();
            await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            return RedirectToAction("Index");
        }
    }
}
