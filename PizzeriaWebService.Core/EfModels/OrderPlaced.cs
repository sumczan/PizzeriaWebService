using System;
using System.Collections.Generic;

namespace PizzeriaWebService.Core.EfModels;

public partial class OrderPlaced
{
    public OrderPlaced()
    {
        OrderBeverages = new HashSet<OrderBeverage>();
        OrderPizzas = new HashSet<OrderPizza>();
    }

    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public decimal OrderPrice { get; set; }
    public int OrderTypeId { get; set; }
    public int OrderStatusId { get; set; }
    public string? ExtraInfo { get; set; }
    public string? PhoneNumber { get; set; }

    public virtual OrderStatus OrderStatus { get; set; } = null!;
    public virtual OrderType OrderType { get; set; } = null!;
    public virtual OrderAddress OrderAddress { get; set; } = null!;
    public virtual ICollection<OrderBeverage> OrderBeverages { get; set; }
    public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
}
