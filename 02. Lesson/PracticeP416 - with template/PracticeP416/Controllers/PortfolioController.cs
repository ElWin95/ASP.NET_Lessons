using Microsoft.AspNetCore.Mvc;

namespace PracticeP416.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
