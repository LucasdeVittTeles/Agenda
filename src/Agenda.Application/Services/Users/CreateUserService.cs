using Agenda.Application.DTOs.Users;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Repositories;

namespace Agenda.Application.Services.Users;

public class CreateUserService : ICreateUserService
{

    private IUserRepository _userRepository;

    public CreateUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {

        var emailExists = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

        if (emailExists)
        {
            throw new ConflictException("E-mail já está cadastrado.");
        }

        var user = new Domain.Entities.Users
        {
            BusinessId = request.BusinessId,
            Name = request.Name,
            Email = request.Email,
            PasswordHash = request.Password, // temporário
            Role = request.Role,
            StaffType = request.StaffType,
            Phone = request.Phone,
            AvatarUrl = request.AvatarUrl,
            Created_At = DateTime.UtcNow,
            Updated_At = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user, cancellationToken);

        await _userRepository.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse
        {
            Id = user.Id,
            BusinessId = user.BusinessId,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            StaffType = user.StaffType,
            Phone = user.Phone,
            AvatarUrl = user.AvatarUrl,
            Created_At = user.Created_At,
            Updated_At = user.Updated_At
        };

    }
}
