using System.ComponentModel.DataAnnotations;

namespace FiorelloP416app.ModelViews.AdminCategory
{
    public class UpdateCategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bosh qoyma...")]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
