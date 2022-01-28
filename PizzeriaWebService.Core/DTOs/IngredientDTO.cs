using System.Runtime.ExceptionServices;

namespace PizzeriaWebService.Core.DTOs;

public class IngredientDTO
{
    public int Id { get; set; }
    public string IngredientName { get; set; } = null!;
    public IngredientTypeDTO IngredientType { get; set; } = null!;
    public decimal IngredientPrice { get; set; }

    public static bool Compare(IngredientDTO first, IngredientDTO second)
    {
        throw new NotImplementedException();
    }
}
