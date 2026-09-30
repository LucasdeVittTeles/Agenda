using Agenda.Application.Interfaces.Repositories;
using Agenda.Domain.Entities;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class BusinessServiceRepository : IBusinessServiceRepository
    {

        private readonly AppDbContext _context;

        public BusinessServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BusinessService?> GetService(int serviceId, CancellationToken cancellationToken = default)
        {

            var businessService = await _context.Services.FindAsync([serviceId], cancellationToken);

            return businessService;

        }

        public async Task<BusinessService> CreateService(BusinessService businessService, CancellationToken cancellationToken = default)
        {

            await _context.Services.AddAsync(businessService, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return businessService;

        }

        public async Task<BusinessService> UpdateService(BusinessService businessService, CancellationToken cancellationToken = default)
        {

            _context.Services.Update(businessService);

            await _context.SaveChangesAsync(cancellationToken);

            return businessService;

        }


        public async Task DeleteService(int serviceId, CancellationToken cancellationToken = default)
        {

            var businessService = await _context.Services.FindAsync(serviceId);

            if (businessService is null)
                return;

            _context.Services.Remove(businessService);

            await _context.SaveChangesAsync(cancellationToken);

        }


        public async Task<List<BusinessService>> GetServicesByBusinessId(int businessId, CancellationToken cancellationToken = default)
        {

            return await _context.Services.Where(s => s.Business_Id == businessId).ToListAsync(cancellationToken);

        }

    }
}
