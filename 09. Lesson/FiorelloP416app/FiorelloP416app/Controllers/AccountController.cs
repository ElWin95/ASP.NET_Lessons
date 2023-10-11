using FiorelloP416app.Entities;
using FiorelloP416app.ModelViews.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser appUser = new();
            appUser.FullName = registerVM.FullName;
            appUser.Email = registerVM.Email;
            appUser.UserName = registerVM.UserName;

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
