namespace PizzeriaWebService.Core.EfModels;

public partial class OrderPizzaIngredientExtra
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public int IngredientId { get; set; }
    public decimal ExtraIngredientPrice { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;
    public virtual OrderPizza OrderPizza { get; set; } = null!;
}