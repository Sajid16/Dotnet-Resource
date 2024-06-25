using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class FluentBookAuthorMap
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual FluentAuthor Author { get; set; }
        public virtual FluentBook Book { get; set; }
    }
}
