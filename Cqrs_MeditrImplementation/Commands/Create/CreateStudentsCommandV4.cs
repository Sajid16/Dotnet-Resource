using Cqrs_MediatR_Implementation.ViewModels;
using MediatR;

namespace Cqrs_MediatR_Implementation.Commands.Create
{
    public record CreateStudentsCommandV4(List<CreateStudentDTO> StudentDTO) : IRequest<bool>;

}
