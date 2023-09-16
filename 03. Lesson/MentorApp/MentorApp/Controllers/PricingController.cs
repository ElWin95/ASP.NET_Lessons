using MentorApp.DAL;
using MentorApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorApp.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public PricingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var pricing = _appDbContext.Pricings.Include(p=>p.PricingServices).ToList();
            var services = _appDbContext.Services.ToList();
            var pricingVM = new PricingVM();
            pricingVM.Pricings = pricing;
            pricingVM.Services = services;

            return View(pricingVM);
        }
    }
}
