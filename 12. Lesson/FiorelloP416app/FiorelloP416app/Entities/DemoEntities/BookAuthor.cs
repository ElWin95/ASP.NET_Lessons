namespace FiorelloP416app.Entities.DemoEntities
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
