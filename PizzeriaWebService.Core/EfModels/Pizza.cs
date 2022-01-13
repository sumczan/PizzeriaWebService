namespace PizzeriaWebService.Core.EfModels;

public partial class Pizza
{
    public Pizza()
    {
        OrderPizzas = new HashSet<OrderPizza>();
        PizzaIngredients = new HashSet<PizzaIngredient>();
    }

    public int Id { get; set; }
    public string PizzaName { get; set; } = null!;
    public decimal PizzaPrice { get; set; }

    public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
    public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
}