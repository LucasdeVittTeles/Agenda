using Agenda.Application.DTOs.Services;

namespace Agenda.Application.Interfaces.Repositories
{
    public interface IServiceRepository
    {

        public Task<List<ServiceResponse>> GetServicesByBusinessId(int businessId, CancellationToken cancellationToken = default);

    }
}
