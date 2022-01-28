using PizzeriaWebService.Core.Exceptions;

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

    public static bool Compare(OrderDTO first, OrderDTO second)
    {
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided OrderDTOs do not match!");
        if (first.OrderTime != second.OrderTime)
            throw new ProvidedObjectNotValidException("OrderTime in provided OrderDTO do not match!");
        if (first.OrderPrice != second.OrderPrice)
            return false;
        if (!OrderTypeDTO.Compare(first.OrderType, second.OrderType))
            return false;
        if (!OrderStatusDTO.Compare(first.OrderStatus, second.OrderStatus))
            return false;
        if (first.ExtraInfo != second.ExtraInfo)
            return false;
        if (first.PhoneNumber != second.PhoneNumber)
            return false;
        if (!OrderAddressDTO.Compare(first.OrderAddress, second.OrderAddress))
            return false;
        if (!OrderPizzaDTO.Compare(first.OrderPizzas, second.OrderPizzas))
            return false;
        if (!OrderBeverageDTO.Compare(first.OrderBeverages, second.OrderBeverages))
            return false;

        return true;
    }
}
