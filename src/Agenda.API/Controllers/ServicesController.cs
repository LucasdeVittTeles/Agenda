using Agenda.Application.DTOs.Services;
using Agenda.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {

        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [Authorize(Policy = "OwnerOrStaff")]
        [HttpGet]
        public async Task<List<ServiceResponse>> Get(CancellationToken cancellationToken)
        {
            return await _servicesService.GetServicesByBusinessId(cancellationToken);
        }
    }
}
