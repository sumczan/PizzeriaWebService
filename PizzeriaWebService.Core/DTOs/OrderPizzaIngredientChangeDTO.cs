namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaIngredientChangeDTO
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public IngredientDTO ToChangeIngredient { get; set; } = null!;
    public IngredientDTO? ChangedIngredient { get; set; }
}
