using FiorelloP416.DAL;
using FiorelloP416app.ModelViews;
using FiorelloP416app.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiorelloP416app.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        private readonly IBasket _basketService;

        public HeaderViewComponent(AppDbContext appDbContext, IBasket basketService)
        {
            _appDbContext = appDbContext;
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Count = _basketService.GetBasketCount();
            var bio = _appDbContext.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }
    }
}
