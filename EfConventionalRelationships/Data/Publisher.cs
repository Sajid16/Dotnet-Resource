using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    [Table("Publishers")]
    public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Book> books { get; set; }
    }
}
