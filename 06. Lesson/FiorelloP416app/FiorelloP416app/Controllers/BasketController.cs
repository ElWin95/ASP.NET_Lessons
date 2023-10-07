using FiorelloP416.DAL;
using FiorelloP416app.Entities;
using FiorelloP416app.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var existProduct = _appDbContext.Products
                .Include(p=>p.ProductImages)
                .FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();

            List<BasketVM> list = CheckBasket();

            CheckBasketItemCount(list, existProduct.Id);
            
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(list), 
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) });
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ShowBasket()
        {
            ////var data = HttpContext.Session.GetString("group");
            //var data = Request.Cookies["group"];
            string basket = Request.Cookies["basket"];
            List<BasketVM> products = new();
            if (basket!=null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                products = UpdateBasket(products);
            }
            //return Content($"value: {products[0].Name}");
            return View(products);
        }
        private List<BasketVM> UpdateBasket(List<BasketVM> products)
        {
            foreach (var basketproduct in products)
            {
                var exitProduct = _appDbContext.Products
                    .Include(p => p.ProductImages)
                    .FirstOrDefault(p => p.Id == basketproduct.Id);
                basketproduct.Name = exitProduct.Name;
                basketproduct.Price = exitProduct.Price;
                basketproduct.ImageUrl = exitProduct.ProductImages.FirstOrDefault(p => p.IsMain).ImageUrl;
            }
            return products;
        }
        private List<BasketVM> CheckBasket()
        {
            List<BasketVM> list;
            string basket = Request.Cookies["basket"];
            if (basket == null)
            {
                list = new();
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            return list;
        }
        private void CheckBasketItemCount(List<BasketVM>list, int id)
        {

            var existProductInBasket = list.FirstOrDefault(p => p.Id == id);
            if (existProductInBasket == null)
            {
                BasketVM basketVM = new();
                basketVM.Id = id;
                basketVM.BasketCount = 1;
                list.Add(basketVM);
            }
            else
            {
                existProductInBasket.BasketCount++;
            }
        }

        public IActionResult Remove(int? id)
        {
            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var basketItem = products.FirstOrDefault(p => p.Id == id);
            if (basketItem != null)
            {
                products.Remove(basketItem);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge=TimeSpan.FromMinutes(20)});
            return RedirectToAction("ShowBasket");
        }

    }
}
