namespace FiorelloP416app.Entities.DemoEntities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public Book()
        {
            BookAuthors = new List<BookAuthor>();
            BookGenres = new List<BookGenre>();
        }
    }
}
