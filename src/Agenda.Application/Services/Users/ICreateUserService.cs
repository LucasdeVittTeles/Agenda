using Agenda.Application.DTOs.Users;

namespace Agenda.Application.Services.Users;

public interface ICreateUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default);

}
