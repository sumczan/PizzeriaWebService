namespace PizzeriaWebService.Core.EfModels;

public partial class ClientBlacklist
{
    public int Id { get; set; }
    public string? PhoneNumber { get; set; }
    public int? CityId { get; set; }
    public string? StreetName { get; set; }
    public string? Apartment { get; set; }
    public string Details { get; set; } = null!;

    public virtual City? City { get; set; }
}