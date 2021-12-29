namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaIngredientExtraDTO
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public IngredientDTO ExtraIngredient { get; set; } = null!;
    public decimal ExtraIngredientPrice { get; set; }
}
