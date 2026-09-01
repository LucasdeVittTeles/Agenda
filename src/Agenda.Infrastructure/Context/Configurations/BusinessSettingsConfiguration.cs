using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class BusinessSettingsConfiguration : IEntityTypeConfiguration<BusinessSettings>
    {

        public void Configure(EntityTypeBuilder<BusinessSettings> builder)
        {

            builder.ToTable("business_settings");

            builder.Property(x => x.Business_Id)
                    .IsRequired();

            builder.HasIndex(x => x.Business_Id)
                    .IsUnique();

            builder.HasOne(x => x.Business)
                     .WithOne(x => x.BusinessSettings)
                     .HasForeignKey<BusinessSettings>(x => x.Business_Id)
                     .IsRequired();

            builder.Property(x => x.Allow_Online_Booking)
                .IsRequired();

            builder.Property(x => x.Max_Daily_Appointments)
               .IsRequired();

            builder.Property(x => x.Appointment_Approval_Required)
                .IsRequired();

            builder.Property(x => x.Appointment_Interval_Minutes)
                .IsRequired();

            builder.Property(x => x.Cancelation_Limit_Hours)
               .IsRequired();

            builder.Property(x => x.Working_Days)
               .HasColumnType("jsonb")
               .IsRequired();

            builder.Property(x => x.Theme_Color)
             .IsRequired(false);

            builder.Property(x => x.Created_At)
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .IsRequired();

        }

    }
}
