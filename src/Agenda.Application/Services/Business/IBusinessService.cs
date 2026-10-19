using Agenda.Application.DTOs.Business;

namespace Agenda.Application.Services.Business;

public interface IBusinessService
{

    Task<BusinessDTO> GetBusiness(CancellationToken cancellationToken = default);
    Task UpdateBusiness(UpdateBusinessDTO updateBusinessDTO, CancellationToken cancellationToken = default);

}
