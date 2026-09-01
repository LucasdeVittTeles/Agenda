using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {

        public void Configure(EntityTypeBuilder<Users> builder)
        {

            builder.ToTable("users");

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasDatabaseName("IX_users_email_unique");

            builder.Property(x => x.BusinessId)
                   .IsRequired();

            builder.HasOne(x => x.Business)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.BusinessId)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.StaffType)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.AvatarUrl)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Created_At)
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .IsRequired();

        }
    }
}
