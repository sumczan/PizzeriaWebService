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
        var isIdentical = true;
     //   isIdentical = first.Id == second.Id;
     //   isIdentical = first.OrderTime == second.OrderTime;
        //isIdentical = first.OrderPrice == second.OrderPrice;
        //isIdentical = first.OrderType == second.OrderType;
        //isIdentical = first.OrderStatus == second.OrderStatus;
        //isIdentical = first.ExtraInfo == second.ExtraInfo;
        //isIdentical = first.PhoneNumber == second.PhoneNumber;
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


        return isIdentical;
    }
}
