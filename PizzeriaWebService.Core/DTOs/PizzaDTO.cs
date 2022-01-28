namespace PizzeriaWebService.Core.DTOs;

public class PizzaDTO
{
    public int Id { get; set; }
    public string PizzaName { get; set; } = null!;
    public decimal PizzaPrice { get; set; }
    public IEnumerable<PizzaIngredientDTO> PizzaIngredients { get; set; } = null!;

    public static bool Compare(PizzaDTO first, PizzaDTO second)
    {
        throw new NotImplementedException();
    }
}
