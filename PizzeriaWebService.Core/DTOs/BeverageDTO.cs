using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public  class BeverageDTO
{
    public int Id { get; set; }
    public string BeverageName { get; set; } = null!;
    public bool IsAlcoholic { get; set; }
    public decimal BeveragePrice { get; set; }

    public static bool Compare(BeverageDTO first, BeverageDTO second)
    {
        if (first.BeverageName != second.BeverageName)
            return false;
        if (first.BeveragePrice != second.BeveragePrice)
            return false;
        if (first.IsAlcoholic != second.IsAlcoholic)
            return false;
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided BeverageDTOs do not match!");
        return true;
    }
}
