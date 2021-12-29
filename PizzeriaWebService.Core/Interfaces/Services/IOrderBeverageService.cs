using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderBeverageService
{
    Task<OrderBeverageDTO> AddOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO);
    Task<OrderBeverageDTO> GetOrderBeverageByIdAsync(int id);
    Task<IEnumerable<OrderBeverageDTO>> GetOrderBeveragesAsync();
    Task<IEnumerable<OrderBeverageDTO>> GetOrderBeveragesByOrderIdAsync(int orderId);
    Task RemoveOrderBeverageAsync(int id);
    Task<OrderBeverageDTO> UpdateOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO);
}
