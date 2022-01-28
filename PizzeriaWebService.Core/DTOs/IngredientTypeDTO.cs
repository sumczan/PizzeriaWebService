using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public  class IngredientTypeDTO
{
    public int Id { get; set; }
    public string IngredientTypeName { get; set; } = null!;
    public bool IsVegan { get; set; }
    public bool IsMeat { get; set; }
    public bool IsVegetable { get; set; }
    public bool IsGlutenFree { get; set; }
    public bool IsDairy { get; set; }

    public static bool Compare(IngredientTypeDTO first, IngredientTypeDTO second)
    {
        if (first.IngredientTypeName != second.IngredientTypeName)
            return false;
        if (first.IsVegan != second.IsVegan)
            return false;
        if (first.IsMeat != second.IsMeat)
            return false;
        if (first.IsVegetable != second.IsVegetable)
            return false;
        if (first.IsGlutenFree != second.IsGlutenFree)
            return false;
        if (first.IsDairy != second.IsDairy)
            return false;
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided IngredientTypeDTOs do not match!");

        return true;
    }
}
