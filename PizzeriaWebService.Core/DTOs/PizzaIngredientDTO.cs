namespace PizzeriaWebService.Core.DTOs;

public class PizzaIngredientDTO
{
    public int Id { get; set; }
    public int PizzaId { get; set; }
    public IngredientDTO Ingredient { get; set; } = null!;

    public static bool Compare(PizzaIngredientDTO first, PizzaIngredientDTO second)
    {
        throw new NotImplementedException();
    }

    public static bool Compare(IEnumerable<PizzaIngredientDTO> first, IEnumerable<PizzaIngredientDTO> second)
    {
        throw new NotImplementedException();
    }
}
