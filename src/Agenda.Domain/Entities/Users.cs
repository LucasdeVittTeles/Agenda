using Agenda.Domain.Enums;

namespace Agenda.Domain.Entities
{
    public class Users
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string? Phone { get; private set; }

        public string? AvatarUrl { get; private set; }

        public int BusinessId { get; private set; }

        public StaffType? StaffType { get; private set; }

        public UserRoles Role { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public List<Availability> Availabilities { get; private set; } = new List<Availability>();

        public List<BlockedTimes> BlockedTimes { get; set; } = new List<BlockedTimes>();

        public ICollection<ServiceStaff> ServiceStaff { get; private set; } = new List<ServiceStaff>();

    }
}
