using Microsoft.AspNetCore.Mvc;

namespace PracticeP416.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
