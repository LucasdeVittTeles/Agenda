using Agenda.Application.DTOs.Users;
using Agenda.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ICreateUserService _createUserService;

        public UsersController(ICreateUserService createUserService)
        {
            _createUserService = createUserService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _createUserService.CreateUserAsync(request, cancellationToken);

            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

    }
}
