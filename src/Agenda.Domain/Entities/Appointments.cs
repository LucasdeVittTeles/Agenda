using Agenda.Domain.Enums;

namespace Agenda.Domain.Entities
{
    public class Appointments
    {

        public int Id { get; set; }
        public int Business_Id { get; set; }
        public int Client_User_Id { get; set; }
        public int Service_Staff_Id { get; set; }
        public DateTime Start_Datetime { get; set; }
        public DateTime End_Datetime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}
