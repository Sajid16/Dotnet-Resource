using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    [Table("Authors")]
    public class Fluent_Author
    {
        //[Key]
        public int Author_Id { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        //[NotMapped]
        public string FullName {
            get { return $"{FirstName} {LastName}"; }
        }
        public List<Fluent_BookAuthorMap> fluent_BookAuthorMaps { get; set; }
    }
}
