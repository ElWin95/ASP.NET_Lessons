﻿namespace FiorelloP416app.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool isDeleted { get; set; }
        public List<Product> Products { get; set; }
    }
}
