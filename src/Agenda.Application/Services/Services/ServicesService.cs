using Agenda.Application.DTOs.Services;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Application.Interfaces.Services;

namespace Agenda.Application.Services.Services
{
    public class ServicesService : IServicesService
    {

        private readonly IServiceRepository _serviceRepository;
        private readonly ICurrentUser _currentUser;

        public ServicesService(IServiceRepository serviceRepository, ICurrentUser currentUser)
        {
            _serviceRepository = serviceRepository;
            _currentUser = currentUser;
        }

        public async Task<List<ServiceResponse>> GetServicesByBusinessId(CancellationToken cancellationToken = default)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            return await _serviceRepository.GetServicesByBusinessId(businessId.Value, cancellationToken);


        }
    }
}
