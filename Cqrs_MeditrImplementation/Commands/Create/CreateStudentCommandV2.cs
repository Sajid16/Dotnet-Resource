using Cqrs_MediatR_Implementation.ViewModels;
using Cqrs_MeditrImplementation.Models;
using MediatR;

namespace Cqrs_MediatR_Implementation.Commands
{
    //public record CreateStudentCommandV2(CreateStudentDTO StudentDTO) : IRequest<StudentDetails>;
    public record CreateStudentCommandV2(CreateStudentDTO StudentDTO) : IRequest<StudentDetails>;
}
