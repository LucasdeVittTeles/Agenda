namespace Agenda.Application.DTOs.Business;

public class UpdateBusinessDTO
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Whatsapp { get; set; } = string.Empty;
    public byte[]? Logo_Data { get; set; }
    public string? Logo_Content_Type { get; set; }
    public string Zip_Code { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

}
