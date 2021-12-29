namespace PizzeriaWebService.Core.EfModels;

public partial class PizzaSize
{
    public PizzaSize()
    {
        OrderPizzas = new HashSet<OrderPizza>();
    }

    public int Id { get; set; }
    public string SizeName { get; set; } = null!;
    public decimal PriceMultiplier { get; set; }

    public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
}
