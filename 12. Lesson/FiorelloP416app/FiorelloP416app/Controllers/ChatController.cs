using FiorelloP416app.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ChatController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult ChatBox()
        {
            ViewBag.Users = _userManager.Users.ToList();
            return View();
        }
    }
}
