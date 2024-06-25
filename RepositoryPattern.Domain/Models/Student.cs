using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPattern.Domain.Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }
    }
}
