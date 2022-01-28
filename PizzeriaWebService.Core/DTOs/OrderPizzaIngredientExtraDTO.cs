namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaIngredientExtraDTO
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public IngredientDTO ExtraIngredient { get; set; } = null!;
    public decimal ExtraIngredientPrice { get; set; }

    public static bool Compare(OrderPizzaIngredientExtraDTO first, OrderPizzaIngredientExtraDTO second)
    {
        throw new NotImplementedException();
    }

    public static bool Compare(IEnumerable<OrderPizzaIngredientExtraDTO> first, IEnumerable<OrderPizzaIngredientExtraDTO> second)
    {
        throw new NotImplementedException();
    }
}
