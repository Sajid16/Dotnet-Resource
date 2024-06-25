using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class FluentBookDetail
    {
        public int BookDetailId { get; set; }
        public double Weight { get; set; }
        public int Chapters { get; set; }
        public int Pages { get; set; }
        public int BookId { get; set; }

        public virtual FluentBook Book { get; set; }
    }
}
