using Agenda.Application.DTOs.Services;

namespace Agenda.Application.Services.Services
{
    public interface IBusinessServicesService
    {
        Task<List<BusinessServiceResponse>> GetServicesByBusinessId(CancellationToken cancellationToken = default);
        Task<BusinessServiceResponse> GetService(int serviceId, CancellationToken cancellationToken = default);
        Task<BusinessServiceResponse> CreateService(CreateBusinessServiceDTO createBusinessServiceDTO, CancellationToken cancellationToken = default);
        Task<BusinessServiceResponse> UpdateService(int serviceId, UpdateBusinessServiceDTO updateBusinessServiceDTO, CancellationToken cancellationToken = default);
        Task DeleteService(int serviceId, CancellationToken cancellationToken = default);

    }
}
