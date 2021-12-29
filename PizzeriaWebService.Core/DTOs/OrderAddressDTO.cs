namespace PizzeriaWebService.Core.DTOs;

public class OrderAddressDTO
{
    public int OrderID { get; set; }
    public CityDTO City { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string Apartment { get; set; } = null!;
}
