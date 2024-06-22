using Cqrs_MediatR_Implementation.Services;
using Cqrs_MeditrImplementation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs_MediatR_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiThreadsController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IExternalApiCallService externalApiCallService;

        public MultiThreadsController(Serilog.ILogger logger, IExternalApiCallService externalApiCallService)
        {
            _logger = logger;
            this.externalApiCallService = externalApiCallService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            List<StudentDetails> students = new List<StudentDetails>();
            for (int i = 0; i < 400; i++)
            {
                StudentDetails student = new StudentDetails
                {
                    Id = i,
                    StudentAge = i,
                    StudentName = "sajid"
                };
                students.Add(student);
            }

            //Thread[] tr = new Thread[4];
            //for (int j = 0; j < 4; j++)
            //{
            //    List<StudentDetails> studentSubList = students.Skip(j * 100).Take(100).ToList();
            //    //tr[t] = new Thread(new ThreadStart(MyThreadMethod(studentSubList)));
            //    var threadIndex = j;

            //    tr[j] = new Thread(() =>
            //    {
            //        foreach (var item in studentSubList)
            //        {
            //            _logger.Information($"info is - {item.Id}:{item.StudentName}:{item.StudentAge} - Thread Name - {threadIndex}");
            //        }
            //    });
            //    tr[j].Start();

            //}

            // Define the number of threads you want to create
            int numberOfThreads = 4;

            // Create and start the threads using a loop
            for (int i = 0; i < numberOfThreads; i++)
            {
                List<StudentDetails> studentSubList = students.Skip(i * 100).Take(100).ToList();

                // Capture the loop variable to avoid closure issues
                int threadIndex = i;

                // Create a new thread and assign it a task
                Thread thread = new Thread(() =>
                {
                    foreach (var item in studentSubList)
                    {
                        //_logger.Information($"info is - {item.Id}:{item.StudentName}:{item.StudentAge} - Thread Index - {threadIndex}");
                        externalApiCallService.ExternalApiCall(item.Id);
                    }
                });

                // Start the thread
                thread.Start();
            }

            return Ok();
        }

        //private ThreadStart MyThreadMethod(List<StudentDetails> studentSubList)
        //{
        //    foreach (var item in studentSubList)
        //    {
        //        _logger.Information($"info is - {item.Id}:{item.StudentName}:{item.StudentAge}");
        //    }

        //}
    }
}
