using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Cqrs_MediatR_Implementation.Commands
{
    public class CreateStudentCommandV3 : IRequest<int>
    {
        [Required(ErrorMessage = "Student Name is Required")]
        public string? StudentName { get; set; }
        [Required(ErrorMessage = "Student Email is Required")]
        public string? StudentEmail { get; set; }
        [Required(ErrorMessage = "Student Address is Required")]
        public string? StudentAddress { get; set; }
        [Required(ErrorMessage = "Student Age is Required")]
        public int StudentAge { get; set; }
    }
}
