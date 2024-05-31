using Cqrs_MediatR_Implementation.Commands;
using Cqrs_MediatR_Implementation.Commands.Create;
using Cqrs_MediatR_Implementation.Notifications;
using Cqrs_MediatR_Implementation.ViewModels;
using Cqrs_MeditrImplementation.Commands;
using Cqrs_MeditrImplementation.Models;
using Cqrs_MeditrImplementation.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs_MeditrImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            var studentDetails = await mediator.Send(new GetStudentListQuery());
            StatusNotification statusNotification = new StatusNotification("get-all-function");
            mediator.Publish(statusNotification);
            return studentDetails;
        }

        [HttpGet("studentId")]
        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            var studentDetails = await mediator.Send(new GetStudentByIdQuery() { Id = studentId });

            return studentDetails;
        }

        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        //public async Task<StudentDetails> AddStudentAsync(CreateStudentDTO createStudentDTO)
        {
            var studentDetail = await mediator.Send(new CreateStudentCommand(
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge));

            return studentDetail;
        }

        [HttpPost]
        [Route("CqrsWithDTOV2")]
        public async Task<StudentDetails> AddStudentAsyncV2(CreateStudentDTO createStudentDTO)
        {
            var studentDetail = await mediator.Send(new CreateStudentCommandV2(createStudentDTO));
            return studentDetail;
        }

        [HttpPost]
        [Route("CqrsWithDTOV3")]
        public async Task<int> AddStudentAsyncV3(CreateStudentCommandV3 createStudentCommandV3)
        {
            var studentDetail = await mediator.Send(createStudentCommandV3);
            return studentDetail;
        }
        
        [HttpPost]
        [Route("CqrsWithListV4")]
        public async Task<bool> AddStudentAsyncV4()
        {
            List<CreateStudentDTO> studentList = new List<CreateStudentDTO>();
            for (int i = 0; i < 1000; i++)
            {
                CreateStudentDTO studentDTO = new CreateStudentDTO
                {
                    StudentName = "sajid",
                    StudentAddress = "malibagh",
                    StudentAge = 30,
                    StudentEmail = "sajid.mahboob@gmail.com"
                };
                studentList.Add(studentDTO);
            }
            var studentDetail = await mediator.Send(new CreateStudentsCommandV4(studentList));

            UpdateNotification updateNotification = new UpdateNotification();
            mediator.Publish(updateNotification);
            return studentDetail;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateStudentCommand(
               studentDetails.Id,
               studentDetails.StudentName,
               studentDetails.StudentEmail,
               studentDetails.StudentAddress,
               studentDetails.StudentAge));
            return isStudentDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await mediator.Send(new DeleteStudentCommand() { Id = Id });
        }
    }
}
