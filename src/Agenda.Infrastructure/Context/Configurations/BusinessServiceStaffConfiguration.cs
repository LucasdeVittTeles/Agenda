using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations;

public class BusinessServiceStaffConfiguration
    : IEntityTypeConfiguration<BusinessServiceStaff>
{
    public void Configure(EntityTypeBuilder<BusinessServiceStaff> builder)
    {
        builder.ToTable("business_service_staff");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Business_Service_Id)
            .HasColumnName("business_service_id")
            .IsRequired();

        builder.HasOne(x => x.BusinessService)
            .WithMany(x => x.Staffs)
            .HasForeignKey(x => x.Business_Service_Id)
            .IsRequired();

        builder.Property(x => x.Staff_User_Id)
            .HasColumnName("staff_user_id")
            .IsRequired();

        builder.HasOne(x => x.StaffUser)
            .WithMany(x => x.BusinessServiceStaffs)
            .HasForeignKey(x => x.Staff_User_Id)
            .IsRequired();

        builder.HasIndex(x => new
        {
            x.Business_Service_Id,
            x.Staff_User_Id
        })
        .IsUnique();

        builder.Property(x => x.Price)
            .HasColumnName("price")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(x => x.Duration_Minutes)
            .HasColumnName("duration_minutes")
            .IsRequired(false);

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