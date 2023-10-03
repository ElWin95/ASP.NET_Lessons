using FiorelloP416.Entities;
using FiorelloP416app.Entities;

namespace FiorelloP416app.ModelViews
{
    public class HomeVM
    {
        public List<Slider> Sliders {  get; set; }
        public List<Category> Categories {  get; set; }
        public List<Product> Products {  get; set; }
        public SliderContent SliderContent { get; set; }
        public List<AboutVM> AboutVMs { get; set; }
        public List<ExpertsVM> ExpertsVMs { get; set; }
        public List<BlogVM> BlogVMs { get; set; }
        public List<Say> Says { get; set; }
        public List<Instagram> Instagrams { get; set; }
    }

    public class AboutVM
    {
        public AboutVM(int id, string title, string description, string imageUrl, List<AboutCheckCircle> aboutCheckCircles)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            AboutCheckCircles = aboutCheckCircles;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<AboutCheckCircle> AboutCheckCircles { get; set; }
    }
    public class ExpertsVM
    {
        public ExpertsVM(int id, string title, string description, List<ExpertName> expertNames)
        {
            Id = id;
            Title = title;
            Description = description;
            ExpertNames = expertNames;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ExpertName> ExpertNames { get; set; }
    }
    public class BlogVM
    {
        public BlogVM(int id, string title, string description, List<BlogCard> blogCards)
        {
            Id = id;
            Title = title;
            Description = description;
            BlogCards = blogCards;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BlogCard> BlogCards { get; set; }
    }
}
