using Microsoft.AspNetCore.Mvc;
using PracticeP416.Models;

namespace PracticeP416.Controllers
{
    public class StudentController : Controller
    {
        private readonly List<Student> _students;
        public StudentController()
        {
            _students = new List<Student>()
           {
               new (){Id=1, StuName="Filankes1", GroupId=1},
               new (){Id=2, StuName="Filankes2", GroupId=2},
               new (){Id=3, StuName="Filankes3", GroupId=3},
               new (){Id=4, StuName="Filankes4", GroupId=4},
               new (){Id=5, StuName="Filankes4", GroupId=2},
               new (){Id=6, StuName="Filankes4", GroupId=3}
           };
        }
        public IActionResult Index(int?id)
        {
            if (id == null) return View(_students);
            if (_students.Exists(s => s.GroupId == id))
            {
                return View(_students.FindAll(s=>s.GroupId==id));
            }
            return NotFound();
        }
        public IActionResult Detail(int? id)
        {
            if (id==null) return BadRequest();
            var existStudent=_students.Find(s => s.Id==id);
            if(existStudent==null) return NotFound();
            return View(existStudent);
        }
    }
}
