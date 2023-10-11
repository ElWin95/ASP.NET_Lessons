namespace FiorelloP416app.Entities
{
    public class Experts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ExpertName> ExpertNames { get; set; }
    }
}
