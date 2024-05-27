using Cqrs_MediatR_Implementation.Commands;
using Cqrs_MeditrImplementation.Commands;
using Cqrs_MeditrImplementation.Models;
using Cqrs_MeditrImplementation.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs_MeditrImplementation.Handlers
{
    public class CreateStudentHandlerV2 : IRequestHandler<CreateStudentCommandV2, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandlerV2(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommandV2 request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = request.StudentDTO.StudentName,
                StudentEmail = request.StudentDTO.StudentEmail,
                StudentAddress = request.StudentDTO.StudentAddress,
                StudentAge = request.StudentDTO.StudentAge
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
