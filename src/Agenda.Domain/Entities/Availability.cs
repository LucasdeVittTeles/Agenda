using Agenda.Domain.Enums;

namespace Agenda.Domain.Entities
{
    public class Availability
    {

        public int Id { get; set; }
        public int User_Id { get; set; }
        public WeekDay Week_Day { get; set; }
        public TimeSpan Start_Time { get; set; }
        public TimeSpan End_Time { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public Users User { get; private set; }

    }
}
