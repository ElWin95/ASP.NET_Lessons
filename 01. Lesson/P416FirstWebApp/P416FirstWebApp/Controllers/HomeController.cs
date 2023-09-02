using Microsoft.AspNetCore.Mvc;
using P416FirstWebApp.Models;

namespace P416FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Student>students= new List<Student>()
        {
            new(){Id = 1, Name="Name1", Age=20},
            new(){Id = 2, Name="Name2", Age=21},
            new(){Id = 3, Name="Name3", Age=23}
        };

        //public IActionResult Index()
        //{
        //    List<Student> stuList = new ();
        //    Student student1 = new ();
        //    student1.Id = 1;
        //    student1.Name = "Test";
        //    student1.Age = 30;

        //    Student student2 = new();
        //    student2.Id = 2;
        //    student2.Name = "Test2";
        //    student2.Age = 20;
        //    stuList.Add (student1);
        //    stuList.Add (student2);
        //    return View(stuList);
        //}
        public IActionResult Index()
        {
            return View(students);
        }
        //public IActionResult About()
        //{
        //    Student student2 = new();
        //    student2.Id = 2;
        //    student2.Name = "Test2";
        //    student2.Age = 20;
        //    return View(student2);
        //}
        public IActionResult About(int id)
        {
            var stu = students.Find(s => s.Id == id);

            return View(stu);
        }
    }
}
