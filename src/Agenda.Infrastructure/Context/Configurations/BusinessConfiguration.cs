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

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Document)
                .HasMaxLength(500)
                .IsRequired();


            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();


            builder.Property(x => x.Phone)
                .HasMaxLength(20)
                .IsRequired();


            builder.Property(x => x.Whatsapp)
                .HasMaxLength(20)
                .IsRequired(false);


            builder.Property(x => x.Logo_Url)
                .HasMaxLength(1000)
                .IsRequired(false);


            builder.Property(x => x.Zip_Code)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.District)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.City)
              .HasMaxLength(150)
              .IsRequired();

            builder.Property(x => x.State)
             .HasMaxLength(150)
             .IsRequired();

            builder.Property(x => x.Country)
                 .HasMaxLength(150)
                 .IsRequired();

            builder.Property(x => x.Subscription)
                 .HasMaxLength(500)
                 .IsRequired();

            builder.Property(x => x.Created_At)
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .IsRequired();

        }

    }
}
