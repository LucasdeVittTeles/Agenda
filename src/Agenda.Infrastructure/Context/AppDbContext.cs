using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<BusinessSettings> BusinessSettings => Set<BusinessSettings>();
        public DbSet<Services> Services => Set<Services>();
        public DbSet<ServiceStaff> ServiceStaff => Set<ServiceStaff>();
        public DbSet<Availability> Availabilities => Set<Availability>();
        public DbSet<BlockedTimes> BlockedTimes => Set<BlockedTimes>();
        public DbSet<Appointments> Appointments => Set<Appointments>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly
            );
        }

    }
}
