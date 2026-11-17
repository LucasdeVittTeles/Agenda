using Agenda.Application.DTOs.BusinessSettings;

namespace Agenda.Application.Services.BusinessSettings
{
    public interface IBusinessSettingsService
    {

        Task<BusinessSettingsResponse> GetBusinessSettings(CancellationToken cancellationToken);
        Task<BusinessSettingsResponse> CreateBusinessSettings(CreateBusinessSettingsRequest createBusinessSettings, CancellationToken cancellationToken);
        Task UpdateBusinessSettings(UpdateBusinessSettingsRequest updateBusinessSettings, CancellationToken cancellationToken);

    }
}
