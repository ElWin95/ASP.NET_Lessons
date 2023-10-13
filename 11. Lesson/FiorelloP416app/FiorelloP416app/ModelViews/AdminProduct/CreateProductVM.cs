﻿using System.ComponentModel.DataAnnotations;

namespace FiorelloP416app.ModelViews.AdminProduct
{
    public class CreateProductVM
    {
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public IFormFile[] Photos { get; set; }
    }
}
