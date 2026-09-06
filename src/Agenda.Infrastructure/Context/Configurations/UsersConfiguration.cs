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

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasDatabaseName("IX_users_email_unique");

            builder.Property(x => x.BusinessId)
                .HasColumnName("business_id")
                .IsRequired();

            builder.HasOne(x => x.Business)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.BusinessId)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("role")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.StaffType)
                .HasColumnName("staff_type")
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.AvatarUrl)
                .HasColumnName("avatar_url")
                .HasMaxLength(500)
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