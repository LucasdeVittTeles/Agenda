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

            builder.Property(x => x.User_Id)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.BlockedTimes)
                .HasForeignKey(x => x.User_Id)
                .IsRequired();

            builder.Property(x => x.Start_Datetime)
                .IsRequired();

            builder.Property(x => x.End_Datetime)
                .IsRequired();

            builder.Property(x => x.Reason)
                .HasMaxLength(255)
                .IsRequired(false);

        }

    }
}
