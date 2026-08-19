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

            // Role
            builder.Property(x => x.Role)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            // StaffType
            builder.Property(x => x.StaffType)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired(false);

            // Phone
            builder.Property(x => x.Phone)
                .HasMaxLength(20)
                .IsRequired();

            // AvatarUrl
            builder.Property(x => x.AvatarUrl)
                .HasMaxLength(500)
                .IsRequired(false);

            // CreatedAt
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            // UpdatedAt
            builder.Property(x => x.UpdatedAt)
                .IsRequired();

        }
    }
}
