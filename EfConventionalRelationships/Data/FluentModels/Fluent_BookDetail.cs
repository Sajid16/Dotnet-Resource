using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    public class Fluent_BookDetail
    {
        //[Key]
        public int BookDetail_Id { get; set; }
        public double Weight { get; set; }
        public int Chapters { get; set; }
        public int Pages { get; set; }
        //[ForeignKey("Book")]
        public int Book_Id { get; set; }
        public Fluent_Book Book { get; set; }
    }
}
