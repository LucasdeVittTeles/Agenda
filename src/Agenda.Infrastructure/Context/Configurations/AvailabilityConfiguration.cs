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

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.User_Id)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Availabilities)
                .HasForeignKey(x => x.User_Id)
                .IsRequired();

            builder.Property(x => x.Week_Day)
                . HasColumnName("week_day")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Start_Time)
                .HasColumnName("start_time")
                .IsRequired();

            builder.Property(x => x.End_Time)
                .HasColumnName("end_time")
                .IsRequired();

            builder.Property(x => x.Is_Active)
                .HasColumnName("is_active")
                .IsRequired();

            builder.Property(x => x.Created_At)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .HasColumnName("updated_at")
                .IsRequired();

        }

    }
}