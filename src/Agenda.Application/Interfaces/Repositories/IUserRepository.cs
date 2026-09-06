using Agenda.Domain.Entities;

namespace Agenda.Application.Interfaces.Repositories;

public interface IUserRepository
{

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task AddAsync(Users user, CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);

}
