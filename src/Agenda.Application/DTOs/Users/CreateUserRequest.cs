using Agenda.Domain.Enums;

namespace Agenda.Application.DTOs.Users;

public class CreateUserRequest
{

    public int BusinessId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRoles Role { get; set; }
    public StaffType? StaffType { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }

}
