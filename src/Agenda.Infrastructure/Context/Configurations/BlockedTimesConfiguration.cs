using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class BlockedTimesConfiguration : IEntityTypeConfiguration<BlockedTimes>
    {

        public void Configure(EntityTypeBuilder<BlockedTimes> builder)
        {

            builder.ToTable("blocked_times");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.User_Id)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.BlockedTimes)
                .HasForeignKey(x => x.User_Id)
                .IsRequired();

            builder.Property(x => x.Start_Datetime)
                .HasColumnName("start_datetime")
                .IsRequired();

            builder.Property(x => x.End_Datetime)
                .HasColumnName("end_datetime")
                .IsRequired();

            builder.Property(x => x.Reason)
                .HasColumnName("reason")
                .HasMaxLength(255)
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