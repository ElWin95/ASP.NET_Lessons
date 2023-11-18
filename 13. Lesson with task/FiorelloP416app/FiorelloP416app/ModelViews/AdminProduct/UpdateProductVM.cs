using System.ComponentModel.DataAnnotations;

namespace FiorelloP416app.ModelViews.AdminProduct
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public IFormFile[]? Photos { get; set; }
        public string? ImageUrl { get; set; }
    }
}
