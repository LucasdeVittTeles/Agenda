using Agenda.Application.DTOs.Users;
using Agenda.Application.Interfaces.Services;
using Agenda.Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ICreateUserService _createUserService;
        private readonly ICurrentUser _currentUser;

        public UsersController(ICreateUserService createUserService, ICurrentUser currentUser)
        {
            _createUserService = createUserService;
            _currentUser = currentUser;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                currentUserRole = _currentUser.Role,

                directRole = User.FindFirstValue(ClaimTypes.Role),

                jwtRole = User.FindFirstValue("role"),

                isInRole = User.IsInRole("Staff")
            });
        }


        [Authorize(Policy = "StaffOnly")]
        [HttpGet("staff")]
        public IActionResult Staff()
        {
            return Ok("Você é Staff.");
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _createUserService.CreateUserAsync(request, cancellationToken);

            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

    }
}
