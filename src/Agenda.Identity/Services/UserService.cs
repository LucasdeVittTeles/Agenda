using Agenda.Domain.Entities;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Identity.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Users?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

    }
}
