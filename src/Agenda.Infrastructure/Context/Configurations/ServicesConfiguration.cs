using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class ServicesConfiguration : IEntityTypeConfiguration<Services>
    {

        public void Configure(EntityTypeBuilder<Services> builder)
        {

            builder.ToTable("services");

            builder.Property(x => x.Business_Id)
                .IsRequired();

            builder.HasOne(x => x.Business)
            .WithMany(x => x.Services)
            .HasForeignKey(x => x.Business_Id)
            .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Default_Duration_Minutes).IsRequired();

            builder.Property(x => x.Is_Active).IsRequired();

            builder.Property(x => x.Created_At)
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .IsRequired();

        }
    }
}
