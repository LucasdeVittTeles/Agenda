using Agenda.Application.DTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    public class RegistrationController : Controller
    {

        [HttpPost]
        public async Task<ActionResult<BusinessServiceResponse>> Create([FromBody]  , CancellationToken cancellationToken)
        {
            var service = await _servicesService.GetService(serviceId, cancellationToken);

            return Ok(service);

        }

    }
}
