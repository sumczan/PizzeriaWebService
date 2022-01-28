using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public class OrderAddressDTO
{
    public int OrderID { get; set; }
    public CityDTO City { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string Apartment { get; set; } = null!;

    public static bool Compare(OrderAddressDTO? first, OrderAddressDTO? second)
    {
        if (first is null && second is null)
            return true;
        if (first is not null && second is null)
            return false;
        if (first is null && second is not null)
            return false;
        if (first.OrderID != second.OrderID)
            throw new ProvidedObjectNotValidException("OrderId in provided OrderAddressDTOs do not match!");
        if (!CityDTO.Compare(first.City, second.City))
            return false;
        if (first.StreetName != second.StreetName)
            return false;
        if (first.Apartment != second.Apartment)
            return false;
        return true;
    }
}
