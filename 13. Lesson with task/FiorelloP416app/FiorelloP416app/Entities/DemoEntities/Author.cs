namespace FiorelloP416app.Entities.DemoEntities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
