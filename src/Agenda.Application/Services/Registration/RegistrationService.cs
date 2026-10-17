using Agenda.Application.DTOs.Registration;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Agenda.Application.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly IPasswordHasher<Domain.Entities.Users> _passwordService;

        public RegistrationService(IUserRepository userRepository, IBusinessRepository businessRepository, IPasswordHasher<Domain.Entities.Users> passwordService)
        {
            _userRepository = userRepository;
            _businessRepository = businessRepository;
            _passwordService = passwordService;
        }

        public async Task<RegistrationResponse> CreateBusinessAndOwner(RegistrationDTO registrationDTO, CancellationToken cancellationToken = default)
        {

            var business = await CreateBusiness(registrationDTO.Business, cancellationToken);

            var user = await CreateOwner(registrationDTO.Owner, business.Id, cancellationToken);

            return new RegistrationResponse { BusinessId = business.Id, UserId = user.Id };

        }


        private async Task<Business> CreateBusiness(CreateBusinessDTO businessDTO, CancellationToken cancellationToken = default)
        {

            var emailExists = await _businessRepository.ExistsByEmailAsync(businessDTO.BusinessEmail, cancellationToken);

            if (emailExists)
            {
                throw new ConflictException("E-mail para estabelecimento já está cadastrado.");
            }

            var business = new Business
            {
                Name = businessDTO.BusinessName,
                Email = businessDTO.BusinessEmail,
                Phone = businessDTO.BusinessPhone,
            };

            return await _businessRepository.AddAsync(business, cancellationToken);

        }


        private async Task<Domain.Entities.Users> CreateOwner(CreateOwnerDTO ownerDTO, int businessId, CancellationToken cancellationToken = default)
        {

            var emailExists = await _userRepository.ExistsByEmailAsync(ownerDTO.Email, cancellationToken);

            if (emailExists)
            {
                throw new ConflictException("E-mail para usuário já está cadastrado.");
            }

            var user = new Domain.Entities.Users
            {
                BusinessId = businessId,
                Name = ownerDTO.Name,
                Email = ownerDTO.Email,
                PasswordHash = _passwordService.HashPassword(null!, ownerDTO.Password), // temporário
                Role = Domain.Enums.UserRoles.Owner,
                StaffType = Domain.Enums.StaffType.Other,
                Phone = ownerDTO.Phone,
                AvatarUrl = "",
                Created_At = DateTime.UtcNow,
                Updated_At = DateTime.UtcNow
            };

            return await _userRepository.AddAsync(user, cancellationToken);

        }

    }
}
