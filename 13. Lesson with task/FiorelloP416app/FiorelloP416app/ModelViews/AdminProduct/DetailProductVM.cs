using FiorelloP416app.Entities;
using System.ComponentModel.DataAnnotations;

namespace FiorelloP416app.ModelViews.AdminProduct
{
    public class DetailProductVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public IFormFile[] Photos { get; set; }
        public ProductImage ProductImage { get; set; }
    }
}
