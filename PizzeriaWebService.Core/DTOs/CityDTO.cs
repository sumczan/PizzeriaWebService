using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public class CityDTO
{
    public int Id { get; set; }
    public string CityName { get; set; } = null!;

    public static bool Compare(CityDTO first, CityDTO second)
    {
        if (first.CityName != second.CityName)
            return false;
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided CityDTO do not match!");
        return true;
    }
}
