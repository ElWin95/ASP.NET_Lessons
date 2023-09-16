using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorApp.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        [MaxLength(100),Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsAdvanced { get; set; }
        public List<PricingService> PricingServices { get; set; }
    } 
    //public class Pricing
    //{
    //    public int Id { get; set; }
    //    [MaxLength(100, ErrorMessage ="100-den yuxari olmaz"),MinLength(20),Required]
    //    [StringLength(100)]
    //    public string Name { get; set; }
    //    [Column(TypeName ="money")]
    //    public double Price { get; set; }
    //    public bool IsFeatured { get; set; }
    //    public bool IsAdvanced { get; set; }
    //}
}
