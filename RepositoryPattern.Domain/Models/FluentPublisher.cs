using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class FluentPublisher
    {
        public FluentPublisher()
        {
            FluentBooks = new HashSet<FluentBook>();
        }

        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<FluentBook> FluentBooks { get; set; }
    }
}
