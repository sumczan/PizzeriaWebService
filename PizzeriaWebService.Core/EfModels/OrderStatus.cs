namespace PizzeriaWebService.Core.EfModels;

public partial class OrderStatus
{
    public OrderStatus()
    {
        OrderPlaceds = new HashSet<OrderPlaced>();
    }

    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    public virtual ICollection<OrderPlaced> OrderPlaceds { get; set; }
}