using Cqrs_MediatR_Implementation.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs_MediatR_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoggersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetLog()
        {
            int i = 0;
            while (i < 5)
            {
                _mediator.Publish(new UpdateNotification());
                i++;
            }
            return Ok("Done");
        }
    }
}
