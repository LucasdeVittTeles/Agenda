namespace Agenda.Domain.Entities
{
    public class BusinessSettings
    {

        public int Id { get; set; }
        public int Business_Id { get; set; }
        public bool Allow_Online_Booking { get; set; }
        public bool Appointment_Approval_Required { get; set; }
        public int Max_Daily_Appointments { get; set; }
        public int Cancelation_Limit_Hours { get; set; }
        public int Appointment_Interval_Minutes { get; set; }
        public List<string> Working_Days { get; set; } = [];
        public string Theme_Color { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public Business Business { get; private set; }

    }
}
