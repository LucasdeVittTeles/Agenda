namespace Agenda.Domain.Entities
{
    public class ServiceStaff
    {
        public int Id { get; set; }
        public int Service_Id { get; set; }
        public int Staff_User_Id { get; set; }
        public decimal Price { get; set; }
        public int? Duration_Minutes { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public Services Service { get; private set; }
        public Users StaffUser { get; private set; }

    }
}
