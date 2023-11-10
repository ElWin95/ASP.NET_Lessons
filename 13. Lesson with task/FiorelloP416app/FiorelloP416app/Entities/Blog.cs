namespace FiorelloP416app.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BlogCard> BlogCards { get; set; }
    }
}
