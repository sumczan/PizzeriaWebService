using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public class OrderStatusDTO
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    public static bool Compare(OrderStatusDTO first, OrderStatusDTO second)
    {
        if (first.StatusName != second.StatusName)
            return false;
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided OrderStatusDTO do not match!");
        return true;
    }
}
