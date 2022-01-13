namespace PizzeriaWebService.Core.EfModels;

public partial class OrderPizza
{
    public OrderPizza()
    {
        OrderPizzaIngredientChanges = new HashSet<OrderPizzaIngredientChange>();
        OrderPizzaIngredientExtras = new HashSet<OrderPizzaIngredientExtra>();
    }

    public int Id { get; set; }
    public int OrderPlacedId { get; set; }
    public int PizzaId { get; set; }
    public int PizzaSizeId { get; set; }
    public decimal OrderPizzaPrice { get; set; }

    public virtual OrderPlaced OrderPlaced { get; set; } = null!;
    public virtual Pizza Pizza { get; set; } = null!;
    public virtual PizzaSize PizzaSize { get; set; } = null!;
    public virtual ICollection<OrderPizzaIngredientChange> OrderPizzaIngredientChanges { get; set; }
    public virtual ICollection<OrderPizzaIngredientExtra> OrderPizzaIngredientExtras { get; set; }
}