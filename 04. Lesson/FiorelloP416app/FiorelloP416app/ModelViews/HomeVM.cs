using FiorelloP416.Entities;
using FiorelloP416app.Entities;

namespace FiorelloP416app.ModelViews
{
    public class HomeVM
    {
        public List<Slider> Sliders {  get; set; }
        public List<Category> Categories {  get; set; }
        public List<Product> Products {  get; set; }
        public SliderContent SliderContent { get; set; }
    }
}
