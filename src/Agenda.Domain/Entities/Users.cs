using Agenda.Domain.Enums;

namespace Agenda.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public int BusinessId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public UserRoles Role { get; set; }

        public StaffType? StaffType { get; set; }

        public string? Phone { get; set; } = string.Empty;

        public string? AvatarUrl { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        // Navigation Properties

        public Business Business { get; private set; }
        public List<Availability> Availabilities { get; private set; } = new List<Availability>();
        public List<BlockedTimes> BlockedTimes { get; set; } = new List<BlockedTimes>();
        public List<ServiceStaff> ServiceStaff { get; private set; } = new List<ServiceStaff>();

    }
}
