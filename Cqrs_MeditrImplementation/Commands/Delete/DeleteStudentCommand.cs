using MediatR;

namespace Cqrs_MeditrImplementation.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
