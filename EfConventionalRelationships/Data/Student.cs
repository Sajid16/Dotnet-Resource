namespace EfConventionalRelationships.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
