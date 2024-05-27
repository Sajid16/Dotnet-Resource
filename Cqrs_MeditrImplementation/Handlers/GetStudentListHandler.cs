using Cqrs_MeditrImplementation.Models;
using Cqrs_MeditrImplementation.Queries;
using Cqrs_MeditrImplementation.Repositories;
using MediatR;

namespace Cqrs_MeditrImplementation.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetails>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
