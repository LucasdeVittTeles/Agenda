namespace Agenda.Domain.Entities
{
    public class BlockedTimes
    {

        public int Id { get; set; }
        public int User_Id { get; set; }
        public TimeSpan Start_Datetime { get; set; }
        public TimeSpan End_Datetime { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public Users User { get; private set; }

    }
}
