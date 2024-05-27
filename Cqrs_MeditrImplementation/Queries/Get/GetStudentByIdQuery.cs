using Cqrs_MeditrImplementation.Models;
using MediatR;

namespace Cqrs_MeditrImplementation.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
