using Agenda.Application.DTOs.Business;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces.Persistence;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Application.Interfaces.Services;

namespace Agenda.Application.Services.Business
{
    public class BusinessService : IBusinessService
    {

        private readonly IBusinessRepository _businessRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IUnitOfWork _unitOfWork;

        public BusinessService(IBusinessRepository businessRepository, ICurrentUser currentUser, IUnitOfWork unitOfWork)
        {
            _businessRepository = businessRepository;
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
        }

        public async Task<BusinessDTO> GetBusiness(CancellationToken cancellationToken = default)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var business = await _businessRepository.GetByIdAsync(businessId, cancellationToken);

            if (business is null)
                throw new BusinessServiceNotFoundException(businessId);

            return new BusinessDTO()
            {
                Name = business.Name,
                Document = business.Document,
                Email = business.Email,
                Phone = business.Phone,
                Whatsapp = business.Whatsapp,
                Zip_Code = business.Zip_Code,
                Street = business.Street,
                Number = business.Number,
                District = business.District,
                City = business.City,
                State = business.State,
                Country = business.Country,
            };

        }

        public async Task UpdateBusiness(UpdateBusinessDTO updateBusinessDTO, CancellationToken cancellationToken = default)
        {

            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            if (businessId == 0)
                throw new ArgumentException("BusinessId deve ser maior que 0.");

            var business = await _businessRepository.GetByIdAsync(businessId, cancellationToken);

            if (business is null)
                throw new BusinessServiceNotFoundException(businessId);

            business.Name = updateBusinessDTO.Name;
            business.Document = updateBusinessDTO.Document;
            business.Email = updateBusinessDTO.Email;
            business.Phone = updateBusinessDTO.Phone;
            business.Whatsapp = updateBusinessDTO.Whatsapp;
            business.Zip_Code = updateBusinessDTO.Zip_Code;
            business.Street = updateBusinessDTO.Street;
            business.Number = updateBusinessDTO.Number;
            business.District = updateBusinessDTO.District;
            business.City = updateBusinessDTO.City;
            business.State = updateBusinessDTO.State;
            business.Country = "Brasil";


            if (updateBusinessDTO.Logo_Data is not null)
            {
                const int maxLogoSize = 2 * 1024 * 1024;

                if (updateBusinessDTO.Logo_Data.Length == 0 ||
                    updateBusinessDTO.Logo_Data.Length > maxLogoSize)
                {
                    throw new ArgumentException(
                        "A imagem deve ter entre 1 byte e 2 MB.");
                }

                var contentType = updateBusinessDTO.Logo_Content_Type;

                if (contentType != "image/png" &&
                    contentType != "image/jpeg")
                {
                    throw new ArgumentException(
                        "Apenas imagens PNG e JPEG são permitidas.");
                }

                business.Logo_Data = updateBusinessDTO.Logo_Data;
                business.Logo_Content_Type = contentType;
            }


            business.Updated_At = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }


        public async Task<(byte[] Data, string ContentType)?> GetBusinessLogo(CancellationToken cancellationToken = default)
        {
            var businessId = _currentUser.BusinessId;

            if (businessId is null)
                throw new BusinessNotBeNullException("BusinessId não pode ser nulo");

            var business = await _businessRepository.GetByIdAsync(
                businessId.Value,
                cancellationToken);

            if (business is null)
                throw new BusinessServiceNotFoundException(businessId.Value);

            if (business.Logo_Data is null ||
                string.IsNullOrEmpty(business.Logo_Content_Type))
            {
                return null;
            }

            return (business.Logo_Data, business.Logo_Content_Type);
        }

    }
}
