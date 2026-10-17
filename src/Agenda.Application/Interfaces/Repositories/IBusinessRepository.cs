using Agenda.Domain.Entities;

namespace Agenda.Application.Interfaces.Repositories;

public interface IBusinessRepository
{

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Business> AddAsync(Business business, CancellationToken cancellationToken = default);

}
