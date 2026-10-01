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
        public async Task<ActionResult<List<BusinessServiceResponse>>> GetList(CancellationToken cancellationToken)
        {
            var services = await _servicesService.GetServicesByBusinessId(cancellationToken);

            return Ok(services);
        }

        [HttpGet("{serviceId:int}")]
        public async Task<ActionResult<BusinessServiceResponse>> Get(int serviceId, CancellationToken cancellationToken)
        {
            var service = await _servicesService.GetService(serviceId, cancellationToken);

            return Ok(service);

        }

        [HttpPost]
        public async Task<ActionResult<BusinessServiceResponse>> Create([FromBody] CreateBusinessServiceDTO createBusinessServiceDTO, CancellationToken cancellationToken)
        {

            var service = await _servicesService.CreateService(createBusinessServiceDTO, cancellationToken);

            return CreatedAtAction(nameof(Get), new { serviceId = service.Id }, service);

        }

        [HttpPut("{serviceId:int}")]
        public async Task<ActionResult<BusinessServiceResponse>> Update(int serviceId, [FromBody] UpdateBusinessServiceDTO updateBusinessServiceDTO, CancellationToken cancellationToken)
        {
            var service = await _servicesService.UpdateService(serviceId, updateBusinessServiceDTO, cancellationToken);

            return Ok(service);

        }

        [HttpDelete("{serviceId:int}")]
        public async Task<IActionResult> Delete(int serviceId, CancellationToken cancellationToken)
        {
            await _servicesService.DeleteService(serviceId, cancellationToken);

            return NoContent();
        }

    }
}
