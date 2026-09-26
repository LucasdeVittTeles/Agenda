using Agenda.Application.DTOs.Services;

namespace Agenda.Application.Services.Services
{
    public interface IServicesService
    {
        Task<List<ServiceResponse>> GetServicesByBusinessId(CancellationToken cancellationToken = default);
    }
}
