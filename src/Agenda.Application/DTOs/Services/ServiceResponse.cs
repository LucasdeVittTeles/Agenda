namespace Agenda.Application.DTOs.Services
{
    public class ServiceResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DefaultDurationMinutes { get; set; }
        public bool Is_Active { get; set; }

        public ServiceResponse(int id, string name, string description, int defaultDurationMinutes, bool is_Active)
        {
            Id = id;
            Name = name;
            Description = description;
            DefaultDurationMinutes = defaultDurationMinutes;
            Is_Active = is_Active;
        }
    }
}
