namespace FiorelloP416app.ModelViews.AdminBook
{
    public class CreateBookVM
    {
        public string Name { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
