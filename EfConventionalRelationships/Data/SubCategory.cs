using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key]
        public int SubCategory_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
