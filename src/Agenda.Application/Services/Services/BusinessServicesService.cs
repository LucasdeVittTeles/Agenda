using Agenda.Application.DTOs.Services;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Application.Interfaces.Services;
using Agenda.Domain.Entities;

namespace Agenda.Application.Services.Services
{
    public class BusinessServicesService : IBusinessServicesService
    {

        private readonly IBusinessServiceRepository _businessServiceRepository;
        private readonly ICurrentUser _currentUser;

        public BusinessServicesService(IBusinessServiceRepository businessServiceRepository, ICurrentUser currentUser)
        {
            _businessServiceRepository = businessServiceRepository;
            _currentUser = currentUser;
        }

        public async Task<BusinessServiceResponse> GetService(int serviceId, CancellationToken cancellationToken = default)
        {

            if (serviceId == 0)
            {
                throw new ArgumentException("serviceId deve ser maior que 0.");
            }

            var businessId = _currentUser.BusinessId;

            var businessService = await _businessServiceRepository.GetService(serviceId, businessId, cancellationToken);

            if (businessService is null)
                throw new BusinessServiceNotFoundException(serviceId);

            return new BusinessServiceResponse(
                businessService.Id,
                businessService.Name,
                businessService.Description,
                businessService.Default_Duration_Minutes,
                businessService.Is_Active
            );

        }

        public async Task<List<BusinessServiceResponse>> GetServicesByBusinessId(CancellationToken cancellationToken = default)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            List<BusinessService> businessServiceList = await _businessServiceRepository.GetServicesByBusinessId(businessId.Value, cancellationToken);

            return businessServiceList.Select(businessService => new BusinessServiceResponse(
                businessService.Id,
                businessService.Name,
                businessService.Description,
                businessService.Default_Duration_Minutes,
                businessService.Is_Active
            )).ToList();
        }

        public async Task<BusinessServiceResponse> CreateService(CreateBusinessServiceDTO createBusinessServiceDTO, CancellationToken cancellationToken = default)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            BusinessService businessService = new BusinessService()
            {
                Name = createBusinessServiceDTO.Name,
                Description = createBusinessServiceDTO.Description,
                Default_Duration_Minutes = createBusinessServiceDTO.DefaultDurationMinutes,
                Is_Active = createBusinessServiceDTO.IsActive,
                Business_Id = businessId.Value,
                Created_At = DateTime.UtcNow,
                Updated_At = DateTime.UtcNow,
            };

            var createdBusinessService = await _businessServiceRepository.CreateService(businessService, cancellationToken);

            return new BusinessServiceResponse(
                createdBusinessService.Id,
                createdBusinessService.Name,
                createdBusinessService.Description,
                createdBusinessService.Default_Duration_Minutes,
                createdBusinessService.Is_Active
            );

        }

        public async Task<BusinessServiceResponse> UpdateService(int serviceId, UpdateBusinessServiceDTO updateBusinessServiceDTO, CancellationToken cancellationToken = default)
        {

            if (serviceId == 0)
                throw new ArgumentException("serviceId deve ser maior que 0.");

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var businessService = await _businessServiceRepository.GetService(serviceId, businessId, cancellationToken);

            if (businessService is null)
                throw new BusinessServiceNotFoundException(serviceId);

            businessService.Name = updateBusinessServiceDTO.Name;
            businessService.Description = updateBusinessServiceDTO.Description;
            businessService.Default_Duration_Minutes = updateBusinessServiceDTO.DefaultDurationMinutes;
            businessService.Is_Active = updateBusinessServiceDTO.IsActive;
            businessService.Updated_At = DateTime.UtcNow;

            var updatedBusinessService = await _businessServiceRepository.UpdateService(businessService, cancellationToken);

            return new BusinessServiceResponse(
                updatedBusinessService.Id,
                updatedBusinessService.Name,
                updatedBusinessService.Description,
                updatedBusinessService.Default_Duration_Minutes,
                updatedBusinessService.Is_Active
            );
        }

        public async Task DeleteService(int serviceId, CancellationToken cancellationToken = default)
        {

            if (serviceId == 0)
                throw new ArgumentException("serviceId deve ser maior que 0.");

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var businessService = await _businessServiceRepository.GetService(serviceId, businessId.Value, cancellationToken);

            if (businessService is null)
                throw new BusinessServiceNotFoundException(serviceId);

            await _businessServiceRepository.DeleteService(businessService, cancellationToken);

        }

    }
}
