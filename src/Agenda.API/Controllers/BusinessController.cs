using Agenda.API.Requests.Business;
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
        public async Task<IActionResult> Update([FromForm] UpdateBusinessRequest request, CancellationToken cancellationToken = default)
        {

            byte[]? logoData = null;

            if (request.Logo is not null &&
                (request.Logo.Length == 0 ||
                 request.Logo.Length > 2 * 1024 * 1024))
            {
                return BadRequest("A imagem deve ter entre 1 byte e 2 MB.");
            }

            if (request.Logo is not null)
            {
                using var stream = new MemoryStream();

                await request.Logo.CopyToAsync(stream, cancellationToken);

                logoData = stream.ToArray();
            }

            var dto = new UpdateBusinessDTO
            {
                Name = request.Name,
                Document = request.Document,
                Email = request.Email,
                Phone = request.Phone,
                Whatsapp = request.Whatsapp,
                Logo_Data = logoData,
                Logo_Content_Type = request.Logo?.ContentType,
                Zip_Code = request.Zip_Code,
                Street = request.Street,
                Number = request.Number,
                District = request.District,
                City = request.City,
                State = request.State,
                Country = request.Country
            };

            await _businessService.UpdateBusiness(dto, cancellationToken);

            return NoContent();

        }

        [HttpGet("logo")]
        public async Task<IActionResult> GetLogo(CancellationToken cancellationToken = default)
        {
            var logo = await _businessService.GetBusinessLogo(cancellationToken);

            if (logo is null)
                return NotFound("Este estabelecimento não possui logo.");

            return File(logo.Value.Data, logo.Value.ContentType);
        }

    }
}
