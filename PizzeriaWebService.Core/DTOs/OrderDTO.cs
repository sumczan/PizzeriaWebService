namespace PizzeriaWebService.Core.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public decimal OrderPrice { get; set; }
    public OrderTypeDTO OrderType { get; set; } = null!;
    public OrderStatusDTO OrderStatus { get; set; } = null!;
    public string? ExtraInfo { get; set; }
    public string? PhoneNumber { get; set; }
    public OrderAddressDTO? OrderAddress { get; set; }
    public IEnumerable<OrderPizzaDTO>? OrderPizzas { get; set; }
    public IEnumerable<OrderBeverageDTO>? OrderBeverages { get; set; }
}
