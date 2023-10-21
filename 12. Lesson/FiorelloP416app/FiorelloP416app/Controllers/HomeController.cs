using FiorelloP416.DAL;
using FiorelloP416.Entities;
using FiorelloP416app.Entities;
using FiorelloP416app.Hubs;
using FiorelloP416app.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416app.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHubContext<ChatHub> _hub;

        public HomeController(AppDbContext appDbContext, IHubContext<ChatHub> hub)
        {
            _appDbContext = appDbContext;
            _hub = hub;
        }

        public IActionResult Index()
        {
            //_hub.Clients.Client("").SendAsync("");
            HomeVM vm = new ();
            vm.Sliders = _appDbContext.Sliders.ToList();
            vm.SliderContent = _appDbContext.SliderContents.FirstOrDefault();
            vm.Categories = _appDbContext.Categories.ToList();
            vm.AboutVMs = _appDbContext.Abouts.Select(a => new AboutVM(a.Id, a.Title, a.Description, a.ImageUrl,
                _appDbContext.AboutCheckCircles.Where(ac => ac.AboutId == a.Id).ToList())).ToList();
            vm.ExpertsVMs = _appDbContext.Experts.Select(e => new ExpertsVM(e.Id, e.Title, e.Description,
                _appDbContext.ExpertNames.Where(en => en.ExpertsId == e.Id).ToList())).ToList();
            vm.BlogVMs = _appDbContext.Blogs.Select(b => new BlogVM(b.Id, b.Title, b.Description,
                _appDbContext.BlogCards.Where(bc => bc.BlogId == b.Id).ToList())).ToList();
            vm.Says = _appDbContext.Says.ToList();
            vm.Instagrams = _appDbContext.Instagrams.ToList();

            //var data = _appDbContext.ChangeTracker.Entries<Slider>().ToList();
            //foreach (var item in data)
            //{
            //    item.Entity.ImageUrl = "test.jpg";
            //}
            //_appDbContext.SaveChanges();

            return View(vm);
        }
    }
}
