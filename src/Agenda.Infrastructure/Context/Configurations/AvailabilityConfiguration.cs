using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {

        public void Configure(EntityTypeBuilder<Availability> builder)
        {

            builder.ToTable("availability");

            builder.Property(x => x.User_Id)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Availabilities)
                .HasForeignKey(x => x.User_Id)
                .IsRequired();

            builder.Property(x => x.Week_Day)
                .IsRequired();

            builder.Property(x => x.Start_Time)
                .IsRequired();

            builder.Property(x => x.End_Time)
                .IsRequired();

        }

    }
}
