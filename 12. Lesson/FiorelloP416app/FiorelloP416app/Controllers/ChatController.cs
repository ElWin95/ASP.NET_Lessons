using Microsoft.AspNetCore.Mvc;

namespace FiorelloP416app.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatBox()
        {
            return View();
        }
    }
}
