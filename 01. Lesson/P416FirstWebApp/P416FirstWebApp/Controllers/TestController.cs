using Microsoft.AspNetCore.Mvc;

namespace P416FirstWebApp.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult Index(string name, string surname, int age)
        //{
        //    return Content($"{name} {surname} {age}"); 
        //}
        //public IActionResult Index(int id)
        //{
        //    return Content($"{id}");
        //}
        //public IActionResult Index()
        //{
        //    return Json(new
        //    {
        //        name="Filankes",
        //        surname="Loremov",
        //        age=34
        //    });
        //}
        public IActionResult Index()
        {
            return File("~/img/website.jpg", "image/jpg");
        }
    }
}
