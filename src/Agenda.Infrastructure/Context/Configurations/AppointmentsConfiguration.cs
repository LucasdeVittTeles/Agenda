using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class AppointmentsConfiguration : IEntityTypeConfiguration<Appointments>
    {
        public void Configure(EntityTypeBuilder<Appointments> builder)
        {

            builder.ToTable("appointments");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Business_Id)
                .HasColumnName("business_id")
                .IsRequired();

            builder.HasOne(x => x.Business)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.Business_Id)
                .IsRequired();

            // Client User

            builder.Property(x => x.Client_User_Id)
                .HasColumnName("client_user_id")
                .IsRequired();

            builder.HasOne(x => x.ClientUser)
                .WithMany()
                .HasForeignKey(x => x.Client_User_Id)
                .IsRequired();

            // Service Staff

            builder.Property(x => x.Service_Staff_Id)
                .HasColumnName("service_staff_id")
                .IsRequired();

            builder.HasOne(x => x.ServiceStaff)
                .WithMany()
                .HasForeignKey(x => x.Service_Staff_Id)
                .IsRequired();

            // Date/Time

            builder.Property(x => x.Start_Datetime)
                .HasColumnName("start_datetime")
                .IsRequired();

            builder.Property(x => x.End_Datetime)
                .HasColumnName("end_datetime")
                .IsRequired();

            // Status

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            // Notes

            builder.Property(x => x.Notes)
                .HasColumnName("notes")
                .IsRequired(false);

            // Audit

            builder.Property(x => x.Created_At)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .HasColumnName("updated_at")
                .IsRequired();

        }

    }
}