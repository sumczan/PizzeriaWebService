namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public PizzaDTO Pizza { get; set; } = null!;
    public PizzaSizeDTO PizzaSize { get; set; } = null!;
    public decimal PizzaPrice { get; set; }
    public IEnumerable<OrderPizzaIngredientChangeDTO>? PizzaIngredientChanges { get; set; }
    public IEnumerable<OrderPizzaIngredientExtraDTO>? PizzaIngredientExtras { get; set; }
}
