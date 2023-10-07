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

        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bio = _appDbContext.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }
    }
}
