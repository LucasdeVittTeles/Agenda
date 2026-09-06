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

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Business_Id)
                .HasColumnName("business_id")
                .IsRequired();

            builder.HasIndex(x => x.Business_Id)
                .IsUnique();

            builder.HasOne(x => x.Business)
                .WithOne(x => x.BusinessSettings)
                .HasForeignKey<BusinessSettings>(x => x.Business_Id)
                .IsRequired();

            builder.Property(x => x.Allow_Online_Booking)
                .HasColumnName("allow_online_booking")
                .IsRequired();

            builder.Property(x => x.Max_Daily_Appointments)
                .HasColumnName("max_daily_appointments")
                .IsRequired();

            builder.Property(x => x.Appointment_Approval_Required)
                .HasColumnName("appointment_approval_required")
                .IsRequired();

            builder.Property(x => x.Appointment_Interval_Minutes)
                .HasColumnName("appointment_interval_minutes")
                .IsRequired();

            builder.Property(x => x.Cancelation_Limit_Hours)
                .HasColumnName("cancelation_limit_hours")
                .IsRequired();

            builder.Property(x => x.Working_Days)
                .HasColumnName("working_days")
                .HasColumnType("jsonb")
                .IsRequired();

            builder.Property(x => x.Theme_Color)
                .HasColumnName("theme_color")
                .IsRequired(false);

            builder.Property(x => x.Created_At)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .HasColumnName("updated_at")
                .IsRequired();

        }

    }
}