using Agenda.Application.Interfaces.Repositories;
using Agenda.Domain.Entities;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {

        private readonly AppDbContext _context;

        public BusinessRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Business?> GetByIdAsync(int? id, CancellationToken cancellationToken = default)
        {

            var business = await _context.Business.FindAsync(id, cancellationToken);

            return business;

        }

        public async Task<Business> AddAsync(Business business, CancellationToken cancellationToken = default)
        {
            await _context.Business.AddAsync(business, cancellationToken);

            return business;
        }


        public async Task<Business> UpdateAsync(Business business, CancellationToken cancellationToken = default)
        {
            _context.Business.Update(business);

            await _context.SaveChangesAsync(cancellationToken);

            return business;
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Business.AnyAsync(x => x.Email == email, cancellationToken);
        }

    }
}
