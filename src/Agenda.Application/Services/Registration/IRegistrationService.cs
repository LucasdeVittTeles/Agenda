using Agenda.Application.DTOs.Registration;
using Agenda.Application.DTOs.Services;

namespace Agenda.Application.Services.Registration
{
    public interface IRegistrationService
    {

        Task<RegistrationResponse> CreateBusinessAndOwner(RegistrationDTO registrationDTO, CancellationToken cancellationToken = default);

    }
}
