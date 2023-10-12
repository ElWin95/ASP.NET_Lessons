using FiorelloP416app.Entities;
using FiorelloP416app.Helpers;
using FiorelloP416app.ModelViews.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

            await _userManager.AddToRoleAsync(appUser, RoleEnum.Member.ToString());

            return RedirectToAction("login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
            if(user == null)
            {
                user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
                if(user == null)
                {
                    ModelState.AddModelError("", "UsernameOrEmail ve ya Password sehvdir");
                    return View(loginVM);
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.Rememberme, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabiniz bloklanib..");
                return View(loginVM);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UsernameOrEmail ve ya Password sehvdir");
                return View(loginVM);
            }

            await _signInManager.SignInAsync(user, loginVM.Rememberme);

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(RoleEnum)))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString()});
            }
            return Content("role created oldu...");
        }

        //public async Task<IActionResult> CreateRole()
        //{
        //    if(await _roleManager.RoleExistsAsync("Member"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    }

        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    return Content("Rollar elave edildi...");
        //} //seed data
    }
}
