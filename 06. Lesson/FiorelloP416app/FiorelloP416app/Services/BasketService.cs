using FiorelloP416app.ModelViews;
using Newtonsoft.Json;

namespace FiorelloP416app.Services
{
    public class BasketService : IBasket
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public BasketService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetBasketCount()
        {
            string basket = _contextAccessor.HttpContext.Request.Cookies["basket"];
            if (basket != null)
            {
                var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                return products.Sum(p => p.BasketCount);
            }
            return 0;
        }
    }
}
