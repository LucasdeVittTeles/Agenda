using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations;

public class BusinessServiceConfiguration
    : IEntityTypeConfiguration<BusinessService>
{
    public void Configure(EntityTypeBuilder<BusinessService> builder)
    {
        builder.ToTable("business_services");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Business_Id)
            .HasColumnName("business_id")
            .IsRequired();

        builder.HasOne(x => x.Business)
            .WithMany(x => x.Services)
            .HasForeignKey(x => x.Business_Id)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(x => x.Default_Duration_Minutes)
            .HasColumnName("default_duration_minutes")
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