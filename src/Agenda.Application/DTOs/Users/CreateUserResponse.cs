using Agenda.Domain.Enums;

namespace Agenda.Application.DTOs.Users
{
    public class CreateUserResponse
    {

        public int Id { get; set; }

        public int BusinessId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UserRoles Role { get; set; }

        public StaffType? StaffType { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string? AvatarUrl { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

    }
}
