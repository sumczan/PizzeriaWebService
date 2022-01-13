namespace PizzeriaWebService.Core.EfModels;

public partial class Ingredient
{
    public Ingredient()
    {
        OrderPizzaIngredientChangeChangedIngredients = new HashSet<OrderPizzaIngredientChange>();
        OrderPizzaIngredientChangeToChangeIngredients = new HashSet<OrderPizzaIngredientChange>();
        OrderPizzaIngredientExtras = new HashSet<OrderPizzaIngredientExtra>();
        PizzaIngredients = new HashSet<PizzaIngredient>();
    }

    public int Id { get; set; }
    public string IngredientName { get; set; } = null!;
    public int IngredientTypeId { get; set; }
    public decimal IngredientPrice { get; set; }

    public virtual IngredientType IngredientType { get; set; } = null!;
    public virtual ICollection<OrderPizzaIngredientChange> OrderPizzaIngredientChangeChangedIngredients { get; set; }
    public virtual ICollection<OrderPizzaIngredientChange> OrderPizzaIngredientChangeToChangeIngredients { get; set; }
    public virtual ICollection<OrderPizzaIngredientExtra> OrderPizzaIngredientExtras { get; set; }
    public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
}