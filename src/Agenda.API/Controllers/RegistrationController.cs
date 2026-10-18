using Agenda.Application.DTOs.Registration;
using Agenda.Application.Services.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {

        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<RegistrationResponse>> Create([FromBody] RegistrationDTO registrationDTO, CancellationToken cancellationToken)
        {
            var registration = await _registrationService.CreateBusinessAndOwner(registrationDTO, cancellationToken);

            return StatusCode(StatusCodes.Status201Created, registration);

        }

    }
}
