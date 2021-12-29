namespace PizzeriaWebService.Core.EfModels;

public partial class OrderType
{
    public OrderType()
    {
        OrderPlaceds = new HashSet<OrderPlaced>();
    }

    public int Id { get; set; }
    public string OrderTypeName { get; set; } = null!;

    public virtual ICollection<OrderPlaced> OrderPlaceds { get; set; }
}
