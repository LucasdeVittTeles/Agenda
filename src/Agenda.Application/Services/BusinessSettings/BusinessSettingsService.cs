using Agenda.Application.DTOs.BusinessSettings;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Application.Interfaces.Services;

namespace Agenda.Application.Services.BusinessSettings
{
    public class BusinessSettingsService : IBusinessSettingsService
    {

        private readonly IBusinessSettingsRepository _repository;
        private readonly ICurrentUser _currentUser;

        public BusinessSettingsService(IBusinessSettingsRepository repository, ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<BusinessSettingsResponse> GetBusinessSettings(CancellationToken cancellationToken)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var business = await _repository.GetByBusinessId(businessId, cancellationToken);

            if (business is null)
                throw new BusinessSettingsNotFoundException();

            return new BusinessSettingsResponse
            {
                Allow_Online_Booking = business.Allow_Online_Booking,
                Appointment_Approval_Required = business.Appointment_Approval_Required,
                Appointment_Interval_Minutes = business.Appointment_Interval_Minutes,
                Cancelation_Limit_Hours = business.Cancelation_Limit_Hours,
                Max_Daily_Appointments = business.Max_Daily_Appointments,
                Theme_Color = business.Theme_Color,
                Working_Days = business.Working_Days
            };

        }

        public async Task<BusinessSettingsResponse> CreateBusinessSettings(CreateBusinessSettingsRequest createBusinessSettings, CancellationToken cancellationToken)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var existingSettings = await _repository.GetByBusinessId(businessId, cancellationToken);

            if (existingSettings is not null)
                throw new BusinessSettingsAlredyExistsExeception();

            Domain.Entities.BusinessSettings businessSettings = new Domain.Entities.BusinessSettings
            {
                Business_Id = businessId.Value,
                Allow_Online_Booking = createBusinessSettings.Allow_Online_Booking,
                Appointment_Interval_Minutes = createBusinessSettings.Appointment_Interval_Minutes,
                Cancelation_Limit_Hours = createBusinessSettings.Cancelation_Limit_Hours,
                Appointment_Approval_Required = createBusinessSettings.Appointment_Approval_Required,
                Max_Daily_Appointments = createBusinessSettings.Max_Daily_Appointments,
                Theme_Color = createBusinessSettings.Theme_Color,
                Working_Days = createBusinessSettings.Working_Days,
                Created_At = DateTime.UtcNow,
                Updated_At = DateTime.UtcNow
            };

            businessSettings = await _repository.Create(businessSettings, cancellationToken);

            return new BusinessSettingsResponse
            {
                Allow_Online_Booking = businessSettings.Allow_Online_Booking,
                Appointment_Approval_Required = businessSettings.Appointment_Approval_Required,
                Appointment_Interval_Minutes = businessSettings.Appointment_Interval_Minutes,
                Cancelation_Limit_Hours = businessSettings.Cancelation_Limit_Hours,
                Max_Daily_Appointments = businessSettings.Max_Daily_Appointments,
                Theme_Color = businessSettings.Theme_Color,
                Working_Days = businessSettings.Working_Days
            };

        }

        public async Task UpdateBusinessSettings(UpdateBusinessSettingsRequest updateBusinessSettings, CancellationToken cancellationToken)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var businessSettings = await _repository.GetByBusinessId(businessId, cancellationToken);

            if (businessSettings is null)
                throw new BusinessSettingsNotFoundException();

            businessSettings.Allow_Online_Booking = updateBusinessSettings.Allow_Online_Booking;
            businessSettings.Appointment_Interval_Minutes = updateBusinessSettings.Appointment_Interval_Minutes;
            businessSettings.Cancelation_Limit_Hours = updateBusinessSettings.Cancelation_Limit_Hours;
            businessSettings.Appointment_Approval_Required = updateBusinessSettings.Appointment_Approval_Required;
            businessSettings.Max_Daily_Appointments = updateBusinessSettings.Max_Daily_Appointments;
            businessSettings.Theme_Color = updateBusinessSettings.Theme_Color;
            businessSettings.Working_Days = updateBusinessSettings.Working_Days;
            businessSettings.Updated_At = DateTime.UtcNow;

            await _repository.Update(cancellationToken);

        }
    }
}
