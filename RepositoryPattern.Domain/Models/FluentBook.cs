using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class FluentBook
    {
        public FluentBook()
        {
            FluentBookAuthorMaps = new HashSet<FluentBookAuthorMap>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }

        public virtual FluentPublisher Publisher { get; set; }
        public virtual FluentBookDetail FluentBookDetail { get; set; }
        public virtual ICollection<FluentBookAuthorMap> FluentBookAuthorMaps { get; set; }
    }
}
