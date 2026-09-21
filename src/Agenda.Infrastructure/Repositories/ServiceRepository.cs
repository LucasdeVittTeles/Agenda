using Agenda.Application.DTOs.Services;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceResponse>> GetServicesByBusinessId(int businessId, CancellationToken cancellationToken = default)
        {

            return await _context.Services
                .Where(s => s.Business_Id == businessId)
                .Select(s => new ServiceResponse
                (
                    s.Id,
                    s.Name,
                    s.Description,
                    s.Default_Duration_Minutes,
                    s.Is_Active
                ))
                .ToListAsync(cancellationToken);

        }
    }
}
