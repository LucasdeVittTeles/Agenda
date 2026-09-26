using Agenda.Domain.Entities;

namespace Agenda.Identity.Services
{
    public interface IUserService
    {
        Task<Users?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    }
}
