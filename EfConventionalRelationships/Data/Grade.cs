namespace EfConventionalRelationships.Data
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
