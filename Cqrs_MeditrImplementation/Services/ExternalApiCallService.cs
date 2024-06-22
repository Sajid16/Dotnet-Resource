namespace Cqrs_MediatR_Implementation.Services
{
    public class ExternalApiCallService : IExternalApiCallService
    {
        private readonly Serilog.ILogger _logger;
        public ExternalApiCallService(Serilog.ILogger logger)
        {
            _logger = logger;
        }
        public Task ExternalApiCall(int index)
        {
            try
            {
                //_logger.Information($"operation start time {DateTime.UtcNow.AddHours(6)}");
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7213/api/Books/get-book-with-details");
                var response = client.SendAsync(request);
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                var result = response.Result.Content.ReadAsStringAsync().Result;

                _logger.Information($"end respone result - {result} - index number - {index} - {DateTime.Now}");
                //Console.WriteLine($"respone is {response} - time {DateTime.UtcNow.AddHours(6)}");

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
