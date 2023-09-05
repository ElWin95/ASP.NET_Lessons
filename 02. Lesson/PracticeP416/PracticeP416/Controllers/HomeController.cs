using Microsoft.AspNetCore.Mvc;
using PracticeP416.Models;
using PracticeP416.ViewModels;

namespace PracticeP416.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["name"] = "Rufet";
            //ViewBag.Surname = "Kerimli";
            ////List<Student> students = new List<Student>() { new() {Id=1, StuName="Filankes"} };
            ////ViewBag.StuList= students;
            //TempData["Age"] = 25;

            ////return View();
            ////return RedirectToAction("index", "student", new {id=1});
            ////return RedirectToAction("About");
            //return RedirectToAction(nameof(About));
            
            //Group group = new();
            //group.Id = 1;
            //group.GroupName = "P416";
            //Student student = new();
            //student.Id = 1;
            //student.GroupId = 1;
            //student.StuName = "Filankes";

            //HomeVM homeVM = new ();
            //homeVM.Group = group;
            //homeVM.Student = student;
            //homeVM.Age = 30;
            //return View(homeVM);

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
