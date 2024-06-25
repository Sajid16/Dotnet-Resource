using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
