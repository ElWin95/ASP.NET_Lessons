using Microsoft.AspNetCore.Mvc;
using PracticeP416.Models;
using PracticeP416.ViewModels;

namespace PracticeP416.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
