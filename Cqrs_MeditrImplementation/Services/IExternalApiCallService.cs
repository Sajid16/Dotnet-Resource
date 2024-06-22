namespace Cqrs_MediatR_Implementation.Services
{
    public interface IExternalApiCallService
    {
        Task ExternalApiCall(int index);
    }
}
