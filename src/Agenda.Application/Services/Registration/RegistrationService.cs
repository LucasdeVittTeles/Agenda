using Agenda.Application.DTOs.Registration;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Persistence;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Domain.Entities;
using Agenda.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Agenda.Application.Services.Registration;

public class RegistrationService : IRegistrationService
{
    private readonly IUserRepository _userRepository;
    private readonly IBusinessRepository _businessRepository;
    private readonly IPasswordHasher<Domain.Entities.Users> _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrationService(
        IUserRepository userRepository,
        IBusinessRepository businessRepository,
        IPasswordHasher<Domain.Entities.Users> passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _businessRepository = businessRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegistrationResponse> CreateBusinessAndOwner(RegistrationDTO registrationDTO, CancellationToken cancellationToken = default)
    {


        var ownerEmailExists = await _userRepository.ExistsByEmailAsync(registrationDTO.Owner.Email, cancellationToken);

        if (ownerEmailExists)
        {
            throw new ConflictException("E-mail para usuário já está cadastrado.");
        }

        var businessEmailExists = await _businessRepository.ExistsByEmailAsync(registrationDTO.Business.BusinessEmail, cancellationToken);

        if (businessEmailExists)
        {
            throw new ConflictException("E-mail para estabelecimento já está cadastrado.");
        }

        var business = CreateBusiness(registrationDTO.Business);

        var owner = CreateOwner(registrationDTO.Owner);

        owner.Business = business;

        await _businessRepository.AddAsync(business, cancellationToken);

        await _userRepository.AddAsync(owner, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RegistrationResponse() { BusinessId = business.Id, UserId = owner.Id };

    }

    private static Domain.Entities.Business CreateBusiness(CreateBusinessDTO businessDTO)
    {
        return new Domain.Entities.Business
        {
            Name = businessDTO.BusinessName,
            Email = businessDTO.BusinessEmail,
            Phone = businessDTO.BusinessPhone,
            Created_At = DateTime.UtcNow,
            Updated_At = DateTime.UtcNow
        };
    }

    private Domain.Entities.Users CreateOwner(CreateOwnerDTO ownerDTO)
    {
        var user = new Domain.Entities.Users
        {
            Name = ownerDTO.Name,
            Email = ownerDTO.Email,
            Role = UserRoles.Owner,
            StaffType = StaffType.Other,
            Phone = ownerDTO.Phone,
            AvatarUrl = "",
            Created_At = DateTime.UtcNow,
            Updated_At = DateTime.UtcNow
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, ownerDTO.Password);

        return user;
    }
}