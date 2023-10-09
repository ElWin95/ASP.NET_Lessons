using FiorelloP416app.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiorelloP416app.Entities.DemoEntities
{
    public class Genre: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        [NotMapped]
        public override int Test { get => base.Test; set => base.Test = value; }
    }
}
