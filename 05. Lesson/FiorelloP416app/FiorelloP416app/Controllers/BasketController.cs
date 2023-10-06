using FiorelloP416.DAL;
using FiorelloP416app.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiorelloP416app.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public BasketController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBasket(int?id)
        {
            ////HttpContext.Session.SetString("group", "P416");
            //Response.Cookies.Append("group", "P416", new CookieOptions { MaxAge=TimeSpan.FromSeconds(30)});
            if (id == null) return NotFound();
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            List<Product> list;
            string basket = Request.Cookies["basket"];
            if (basket==null)
            {
                list = new();
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<Product>>(basket);
            }

            
            list.Add(existProduct);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(list), 
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) });
            return Content("set olundu....");
        }
        public IActionResult ShowBasket()
        {
            ////var data = HttpContext.Session.GetString("group");
            //var data = Request.Cookies["group"];
            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<Product>>(basket);
            return Content($"value: {products[0].Name}");
        }

    }
}
