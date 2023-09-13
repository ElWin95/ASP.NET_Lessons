using Microsoft.AspNetCore.Mvc;

namespace PracticeP416.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
