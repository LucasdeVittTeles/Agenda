using Agenda.Application.DTOs.Business;
using Agenda.Application.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "OwnerOrStaff")]
    public class BusinessController : ControllerBase
    {

        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }


        [HttpGet]
        public async Task<ActionResult<BusinessDTO>> Get(CancellationToken cancellationToken = default)
        {

            var business = await _businessService.GetBusiness();

            return Ok(business);

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBusinessDTO updateBusinessDTO, CancellationToken cancellationToken = default)
        {

            await _businessService.UpdateBusiness(updateBusinessDTO, cancellationToken);

            return NoContent();

        }

    }
}
