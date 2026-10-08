using Agenda.Domain.Entities;

namespace Agenda.Application.Interfaces.Repositories;

public interface IBusinessServiceRepository
{
    Task<List<BusinessService>> GetServicesByBusinessId(int businessId, CancellationToken cancellationToken = default);

    Task<BusinessService> GetService(int serviceId, int? businessId, CancellationToken cancellationToken = default);

    Task<BusinessService> CreateService(BusinessService BusinessService, CancellationToken cancellationToken = default);

    Task<BusinessService> UpdateService(BusinessService BusinessService, CancellationToken cancellationToken = default);

    Task DeleteService(BusinessService BusinessService, CancellationToken cancellationToken = default);
}