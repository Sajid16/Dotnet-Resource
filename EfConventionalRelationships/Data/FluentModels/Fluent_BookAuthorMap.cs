using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    public class Fluent_BookAuthorMap
    {
        //[ForeignKey("Book")]
        public int Book_Id { get; set; }
        //[ForeignKey("Author")]
        public int Author_Id { get; set; }
        public Fluent_Book Book { get; set; }
        public Fluent_Author Author { get; set; }
    }
}
