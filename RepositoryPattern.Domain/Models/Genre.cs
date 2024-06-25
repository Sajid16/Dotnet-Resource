using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int Display { get; set; }
    }
}
