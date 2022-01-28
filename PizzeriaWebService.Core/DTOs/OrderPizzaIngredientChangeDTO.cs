namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaIngredientChangeDTO
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public IngredientDTO ToChangeIngredient { get; set; } = null!;
    public IngredientDTO? ChangedIngredient { get; set; }

    public static bool Compare(OrderPizzaIngredientChangeDTO first, OrderPizzaIngredientChangeDTO second)
    {
        throw new NotImplementedException();
    }

    public static bool Compare(IEnumerable<OrderPizzaIngredientChangeDTO> first, IEnumerable<OrderPizzaIngredientChangeDTO> second)
    {
        throw new NotImplementedException();
    }
}
