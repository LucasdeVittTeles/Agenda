using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Context.Configurations
{
    public class AppointmentsConfiguration : IEntityTypeConfiguration<Appointments>
    {
        public void Configure(EntityTypeBuilder<Appointments> builder)
        {

            builder.ToTable("appointments");

            builder.Property(x => x.Business_Id)
                .IsRequired();

            builder.Property(x => x.Client_User_Id)
                .IsRequired();

            builder.Property(x => x.Service_Staff_Id)
            .IsRequired();

            builder.Property(x => x.Start_Datetime)
               .IsRequired();

            builder.Property(x => x.End_Datetime)
              .IsRequired();

            builder.Property(x => x.Notes)
              .IsRequired(false);

            builder.Property(x => x.Created_At)
               .IsRequired();

            builder.Property(x => x.Updated_At)
               .IsRequired();

        }

    }
}
