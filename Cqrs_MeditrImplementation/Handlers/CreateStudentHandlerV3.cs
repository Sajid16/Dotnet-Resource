using Cqrs_MediatR_Implementation.Commands;
using Cqrs_MeditrImplementation.Commands;
using Cqrs_MeditrImplementation.Models;
using Cqrs_MeditrImplementation.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs_MeditrImplementation.Handlers
{
    public class CreateStudentHandlerV3 : IRequestHandler<CreateStudentCommandV3, int>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandlerV3(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CreateStudentCommandV3 request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = request.StudentName,
                StudentEmail = request.StudentEmail,
                StudentAddress = request.StudentAddress,
                StudentAge = request.StudentAge
            };

            var response = await _studentRepository.AddStudentAsync(studentDetails);
            if (response is not null) return 1;
            return 0;
        }
    }
}
