using Agenda.Application.DTOs.BusinessSettings;
using Agenda.Application.Services.BusinessSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "OwnerOrStaff")]
    public class BusinessSettingsController : ControllerBase
    {

        private readonly IBusinessSettingsService _businessSettingsService;

        public BusinessSettingsController(IBusinessSettingsService businessSettingsService)
        {
            _businessSettingsService = businessSettingsService;
        }


        [HttpGet]
        public async Task<ActionResult<BusinessSettingsResponse>> Get(CancellationToken cancellationToken = default)
        {

            var businessSettings = await _businessSettingsService.GetBusinessSettings(cancellationToken);

            return Ok(businessSettings);

        }

        [HttpPost]
        public async Task<ActionResult<BusinessSettingsResponse>> Create([FromBody] CreateBusinessSettingsRequest request, CancellationToken cancellationToken = default)
        {

            var businessSettings = await _businessSettingsService.CreateBusinessSettings(request, cancellationToken);

            return CreatedAtAction(nameof(Get), value: businessSettings);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBusinessSettingsRequest request, CancellationToken cancellationToken = default)
        {

            await _businessSettingsService.UpdateBusinessSettings(request, cancellationToken);

            return NoContent();

        }
    }
}
