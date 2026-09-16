using Agenda.Application.Services.Password;
using Agenda.Identity.Models;
using Agenda.Identity.Services;
using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IIdentityServerInteractionService _interactionService;

        public AccountController(
            IUserService userService,
            IPasswordService passwordService,
            IIdentityServerInteractionService interactionService)
        {
            _userService = userService;
            _passwordService = passwordService;
            _interactionService = interactionService;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            return View(new LoginInputModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, CancellationToken cancellationToken){

            if (!ModelState.IsValid)
                return View(model);

            if (string.IsNullOrWhiteSpace(model.ReturnUrl) || !_interactionService.IsValidReturnUrl(model.ReturnUrl))
            {
                return BadRequest();
            }

            var user = await _userService.GetByEmailAsync(
                model.Email,
                cancellationToken);

            if (user is null || !_passwordService.VerifyPassword(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");

                return View(model);
            }

            var identityServerUser = new IdentityServerUser(user.Id.ToString())
            {
                DisplayName = user.Name
            };

            identityServerUser.AdditionalClaims.Add(new("role", user.Role.ToString()));

            if (user.BusinessId > 0)
            {
                identityServerUser.AdditionalClaims.Add(new("business_id", user.BusinessId.ToString()));
            }

            await HttpContext.SignInAsync(identityServerUser);

            return Redirect(model.ReturnUrl);
        }
    }
}
