using Cqrs_MeditrImplementation.Models;
using MediatR;

namespace Cqrs_MeditrImplementation.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}
