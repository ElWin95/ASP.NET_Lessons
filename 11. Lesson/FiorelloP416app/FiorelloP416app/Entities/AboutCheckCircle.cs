namespace FiorelloP416app.Entities
{
    public class AboutCheckCircle
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
