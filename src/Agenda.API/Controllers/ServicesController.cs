using Agenda.Application.DTOs.Services;
using Agenda.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "OwnerOrStaff")]
    public class ServicesController : ControllerBase
    {

        private readonly IBusinessServicesService _servicesService;

        public ServicesController(IBusinessServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet]
        public async Task<List<BusinessServiceResponse>> GetList(CancellationToken cancellationToken)
        {
            return await _servicesService.GetServicesByBusinessId(cancellationToken);
        }

        [HttpGet]
        public async Task<BusinessServiceResponse> Get(int serviceId, CancellationToken cancellationToken)
        {
            return await _servicesService.GetService(serviceId, cancellationToken);
        }

        [HttpPost]
        public async Task<BusinessServiceResponse> Create(CreateBusinessServiceDTO createBusinessServiceDTO, CancellationToken cancellationToken)
        {

            return await _servicesService.CreateService(createBusinessServiceDTO, cancellationToken);

        }

        [HttpPatch]
        public async Task<BusinessServiceResponse> Update(int serviceId, UpdateBusinessServiceDTO updateBusinessServiceDTO, CancellationToken cancellationToken)
        {
            return await _servicesService.UpdateService(serviceId, updateBusinessServiceDTO, cancellationToken);
        }

        [HttpDelete]
        public async Task Delete(int serviceId, CancellationToken cancellationToken)
        {
            await _servicesService.DeleteService(serviceId, cancellationToken);
        }

    }
}
