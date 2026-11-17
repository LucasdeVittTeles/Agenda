using Agenda.Application.Interfaces.Repositories;
using Agenda.Domain.Entities;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class BusinessSettingsRepository : IBusinessSettingsRepository
    {

        private readonly AppDbContext _context;

        public BusinessSettingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BusinessSettings?> GetByBusinessId(int? businessId, CancellationToken cancellationToken)
        {

            var businessSettings = await _context.BusinessSettings.FirstOrDefaultAsync(bs => bs.Business_Id == businessId, cancellationToken);

            return businessSettings;

        }


        public async Task<BusinessSettings> Create(BusinessSettings businessSettings, CancellationToken cancellationToken)
        {

            await _context.BusinessSettings.AddAsync(businessSettings, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return businessSettings;

        }


        public async Task Update(CancellationToken cancellationToken)
        {

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
