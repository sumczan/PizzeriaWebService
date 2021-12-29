namespace PizzeriaWebService.Core.DTOs;

public class IngredientDTO
{
    public int Id { get; set; }
    public string IngredientName { get; set; } = null!;
    public IngredientTypeDTO IngredientType { get; set; } = null!;
    public decimal IngredientPrice { get; set; }
}
