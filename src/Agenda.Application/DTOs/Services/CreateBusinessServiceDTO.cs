namespace Agenda.Application.DTOs.Services;

public class CreateBusinessServiceDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DefaultDurationMinutes { get; set; }
    public bool Is_Active { get; set; }

}
