using FiorelloP416.Entities;
using FiorelloP416app.Entities;
using FiorelloP416app.Entities.DemoEntities;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutCheckCircle> AboutCheckCircles { get; set; }
        public DbSet<Experts> Experts { get; set; }
        public DbSet<ExpertName> ExpertNames { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCard> BlogCards { get; set; }
        public DbSet<Say> Says { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        public DbSet <Bio> Bios { get; set; }
        public DbSet <Book> Books { get; set; }
        public DbSet <Genre> Genres { get; set; }
        public DbSet <Author> Authors { get; set; }
        public DbSet <BookAuthor> BookAuthors { get; set; }
        public DbSet <BookGenre> BookGenres { get; set; }
        public DbSet <BookImage> BookImages { get; set; }
    }
}
