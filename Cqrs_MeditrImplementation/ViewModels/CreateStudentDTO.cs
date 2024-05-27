using System.ComponentModel.DataAnnotations;

namespace Cqrs_MediatR_Implementation.ViewModels
{
    public class CreateStudentDTO
    {
        [Required(ErrorMessage = "Student Name is Required")]
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public string? StudentAddress { get; set; }
        public int StudentAge { get; set; }
    }
}
