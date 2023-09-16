using MentorApp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MentorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Features.ToList());
        }
    }
}
