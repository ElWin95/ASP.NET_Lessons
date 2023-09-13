using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeP416.DAL;
using PracticeP416.Models;
using PracticeP416.Services;

namespace PracticeP416.Controllers
{
    public class HomeController : Controller
    {
        //Dependency injection
        //private readonly ILogin _loginService;
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        //public AppDbContext MyProperty { get; set; }
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //public HomeController(AppDbContext appDbContext, IConfiguration configuration)
        //{
        //    _appDbContext = appDbContext;
        //    _configuration = configuration;
        //}
        //public HomeController(AppDbContext appDbContext, ILogin loginService)
        //{
        //    _appDbContext = appDbContext;
        //    _loginService = loginService;
        //}
        //public HomeController(AppDbContext appDbContext, IConfiguration configuration)
        //{
        //    MyProperty = new AppDbContext("");
        //}
        //public IActionResult Index([FromServices]IConfiguration configuration, [FromServices]AppDbContext appDbContext)
        //{
        //    string name = _configuration.GetSection("StuName").Value;
        //    return View();
        //} 
        //public IActionResult Index()
        //{
        //    string name = _configuration.GetSection("StuName").Value;
        //    return View();
        //} 
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.ToList();
        //    var students = _appDbContext.Students.ToList();
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.Where(g=>g.Id>3&&g.GroupName.Contains("A")).ToList();
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.Single(g => g.Id == 3);
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.SingleOrDefault(g => g.Id == 3);
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.FirstOrDefault(g => g.Id > 3);
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.First(g=>g.Id==3);
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var groups = _appDbContext.Groups.Find(1,2);
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    List<Group> groups = _appDbContext.Groups.ToList();
        //    return View(groups);
        //}
        //public IActionResult Index()
        //{
        //    var students = _appDbContext.Students.Include(s=>s.Group).ToList();
        //    return View(students);
        //}
        public IActionResult Index()
        {
            var count = _appDbContext.Students.Count();
            return View(count);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
