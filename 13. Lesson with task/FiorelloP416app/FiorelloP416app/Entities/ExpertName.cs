namespace FiorelloP416app.Entities
{
    public class ExpertName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string ImageUrl { get; set; }
        public int ExpertsId { get; set; }
        public Experts Experts { get; set; }
    }
}
