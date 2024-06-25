using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class FluentAuthor
    {
        public FluentAuthor()
        {
            FluentBookAuthorMaps = new HashSet<FluentBookAuthorMap>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }

        public virtual ICollection<FluentBookAuthorMap> FluentBookAuthorMaps { get; set; }
    }
}
