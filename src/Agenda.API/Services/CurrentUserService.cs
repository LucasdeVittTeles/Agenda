using Agenda.Application.Interfaces.Services;
using System.Security.Claims;

namespace Agenda.API.Services;

public class CurrentUserService : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? User =>
        _httpContextAccessor.HttpContext?.User;

    public int UserId
    {
        get
        {
            var value =
                User?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User?.FindFirstValue("sub");

            return int.Parse(
                value ?? throw new UnauthorizedAccessException());
        }
    }

    public string? Role =>
        User?.FindFirstValue(ClaimTypes.Role) ??
        User?.FindFirstValue("role");

    public int? BusinessId
    {
        get
        {
            var value = User?.FindFirstValue("business_id");

            return int.TryParse(value, out var businessId)
                ? businessId
                : null;
        }
    }

    public bool IsAuthenticated =>
        User?.Identity?.IsAuthenticated ?? false;
}