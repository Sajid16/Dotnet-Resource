using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class Book
    {
        //public Book()
        //{
        //    BookAuthorMaps = new HashSet<BookAuthorMap>();
        //}

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual BookDetail BookDetail { get; set; }
        public virtual ICollection<BookAuthorMap> BookAuthorMaps { get; set; }
    }
}
