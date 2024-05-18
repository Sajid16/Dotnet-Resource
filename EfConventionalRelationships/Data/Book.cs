using System.ComponentModel.DataAnnotations.Schema;

namespace EfConventionalRelationships.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public BookDetail BookDetail { get; set; }
        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }
        public List<BookAuthorMap> bookAuthorMaps { get; set; }

    }
}
