namespace Agenda.Domain.Entities
{
    public class Services
    {

        public int Id { get; set; }
        public int Business_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Default_Duration_Minutes { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }


    }
}
