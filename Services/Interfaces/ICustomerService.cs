using Models.DTOs.Output;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerSocialNetworksDTO>> GetCustomersWithSocialNetworksAsync(CancellationToken cancellationToken);
        Task<double?> GetWorkingHoursByCustomerId(int id, CancellationToken cancellationToken);
    }
}
