using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    public class Fluent_Book
    {
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public Fluent_BookDetail BookDetail { get; set; }
        //[ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Fluent_Publisher Publisher { get; set; }
        public List<Fluent_BookAuthorMap> fluent_BookAuthorMaps { get; set; }
    }
}
