using System.Runtime.ExceptionServices;
using PizzeriaWebService.Core.Exceptions;

namespace PizzeriaWebService.Core.DTOs;

public class OrderBeverageDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public BeverageDTO BeverageDTO { get; set; } = null!;

    public static bool Compare(OrderBeverageDTO first, OrderBeverageDTO second)
    {
        if (first is null && second is null)
            return true;
        if (first is null && second is not null)
            return false;
        if (first is not null && second is null)
            return false;
        if (first.OrderId != second.OrderId)
            throw new ProvidedObjectNotValidException("OrderId in provided OrderBeverageDTOs do not match!");
        if (first.Id != second.Id)
            throw new ProvidedObjectNotValidException("Id in provided OrderBeverageDTOs do not match!");
        if (!DTOs.BeverageDTO.Compare(first.BeverageDTO, second.BeverageDTO))
            return false;
        return true;
    }

    public static bool Compare(IEnumerable<OrderBeverageDTO> first, IEnumerable<OrderBeverageDTO> second)
    {
        if (first.Count() != second.Count())
            return false;
        for (int i = 0; i < first.Count(); i++)
        {
            if (!Compare(first.ElementAt(i), second.ElementAt(i)))
                return false;
        }

        return true;
    }
}
