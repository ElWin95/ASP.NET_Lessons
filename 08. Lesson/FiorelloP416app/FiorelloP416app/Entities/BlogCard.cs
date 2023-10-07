namespace FiorelloP416app.Entities
{
    public class BlogCard
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }  
        public string ImageUrl { get; set; }  
        public int BlogId { get; set; }  
        public Blog Blog { get; set; }  
    }
}
