using Agenda.Domain.Entities;

namespace Agenda.Application.Interfaces.Repositories
{
    public interface IBusinessSettingsRepository
    {
        Task<BusinessSettings> GetByBusinessId(int? businessId, CancellationToken cancellationToken);
        Task<BusinessSettings> Create(BusinessSettings businessSettings, CancellationToken cancellationToken);
        Task Update(CancellationToken cancellationToken);

    }
}
