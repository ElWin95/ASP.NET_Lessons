using Microsoft.AspNetCore.Mvc;
using PracticeP416.Models;

namespace PracticeP416.Controllers
{
    public class GroupController : Controller
    {
        private List<Group> _groups;
        public GroupController()
        {
            _groups = new()
            {
                new() {Id= 1, GroupName="P416"},
                new() {Id= 2, GroupName="P417"},
                new() {Id= 3, GroupName="P418"},
                new() {Id= 4, GroupName="P419"}
            };
        }
        public IActionResult Index()
        {
            return View(_groups);
        }
    }
}
