using Cqrs_MediatR_Implementation.ViewModels;
using Cqrs_MeditrImplementation.Models;
using Cqrs_MeditrImplementation.Repositories;
using MediatR;

namespace Cqrs_MediatR_Implementation.Notifications
{
    public class UpdateNotificationHandler : INotificationHandler<UpdateNotification>
    {
        private readonly IStudentRepository repository;

        public UpdateNotificationHandler(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                //await Task.Delay(10000);
                Console.WriteLine($"operation start time {DateTime.UtcNow.AddHours(6)}");
                
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7213/api/Books/get-book-with-details");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                Console.WriteLine($"respone is {response} - time {DateTime.UtcNow.AddHours(6)}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
