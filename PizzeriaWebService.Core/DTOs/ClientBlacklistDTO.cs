namespace PizzeriaWebService.Core.DTOs;

public class ClientBlacklistDTO
{
    public int Id { get; set; }
    public string? PhoneNumber { get; set; }
    public CityDTO? City { get; set; }
    public string? StreetName { get; set; }
    public string? Apartment { get; set; }
    public string Details { get; set; } = null!;
}
