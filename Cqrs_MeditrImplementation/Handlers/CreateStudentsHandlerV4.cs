using Cqrs_MediatR_Implementation.Commands.Create;
using Cqrs_MeditrImplementation.Models;
using Cqrs_MeditrImplementation.Repositories;
using MediatR;

namespace Cqrs_MediatR_Implementation.Handlers
{
    public class CreateStudentsHandlerV4 : IRequestHandler<CreateStudentsCommandV4, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentsHandlerV4(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<bool> Handle(CreateStudentsCommandV4 request, CancellationToken cancellationToken)
        {
            List<StudentDetails> studentList = new List<StudentDetails>();
            foreach (var item in request.StudentDTO)
            {
                var studentDetails = new StudentDetails()
                {
                    StudentName = item.StudentName,
                    StudentEmail = item.StudentEmail,
                    StudentAddress = item.StudentAddress,
                    StudentAge = item.StudentAge
                };
                studentList.Add(studentDetails);
            }

            var response = await _studentRepository.AddStudentAllAsync(studentList);
            return response;
        }
    }
}
