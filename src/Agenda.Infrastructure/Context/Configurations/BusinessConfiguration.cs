using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Agenda.Infrastructure.Context.Configurations
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {

        public void Configure(EntityTypeBuilder<Business> builder)
        {

            builder.ToTable("business");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Document)
                .HasColumnName("document")
                .HasMaxLength(500)
                .IsRequired();


            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();


            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20)
                .IsRequired();


            builder.Property(x => x.Whatsapp)
                .HasColumnName("whatsapp")
                .HasMaxLength(20)
                .IsRequired(false);


            builder.Property(x => x.Logo_Url)
                .HasColumnName("logo_url")
                .HasMaxLength(1000)
                .IsRequired(false);


            builder.Property(x => x.Zip_Code)
                .HasColumnName("zip_code")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasColumnName("street")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnName("number")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.District)
                .HasColumnName("district")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.City)
              .HasColumnName("city")
              .HasMaxLength(150)
              .IsRequired();

            builder.Property(x => x.State)
             .HasColumnName("state")
             .HasMaxLength(150)
             .IsRequired();

            builder.Property(x => x.Country)
                 .HasColumnName("country")
                 .HasMaxLength(150)
                 .IsRequired();

            builder.Property(x => x.Subscription)
                 .HasColumnName("subscription")
                 .HasMaxLength(500)
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