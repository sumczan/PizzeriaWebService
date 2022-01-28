using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public class OrderTypeDTO
{
    public int Id { get; set; }
    public string OrderTypeName { get; set; } = null!;

    public static bool Compare(OrderTypeDTO first, OrderTypeDTO second)
    {
        if(first.OrderTypeName != second.OrderTypeName)
            return false;
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided OrderTypeDTO do not match!");
        return true;
    }
}
