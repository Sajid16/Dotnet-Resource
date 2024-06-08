using Cqrs_MeditrImplementation.Repositories;
using MediatR;

namespace Cqrs_MediatR_Implementation.Notifications
{
    public class UpdateNotificationHandler : INotificationHandler<UpdateNotification>
    {
        private readonly IStudentRepository repository;
        private readonly Serilog.ILogger _logger;
        //private readonly ILogger _logger;

        public UpdateNotificationHandler(IStudentRepository repository, Serilog.ILogger logger)
        {
            this.repository = repository;
            _logger = logger;
        }

        public async Task Handle(UpdateNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                //await Task.Delay(5000);
                //Console.WriteLine($"operation start time {DateTime.UtcNow.AddHours(6)}");
                _logger.Information($"operation start time {DateTime.UtcNow.AddHours(6)}");
                _logger.Error(new Exception("self made exception test"), "Exception");
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7213/api/Books/get-book-with-details");
                var response = await client.SendAsync(request);
                //response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                var result = await response.Content.ReadAsStringAsync();

                _logger.Information($"end respone result - {result} - {DateTime.Now}", "Okay");
                //Console.WriteLine($"respone is {response} - time {DateTime.UtcNow.AddHours(6)}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
