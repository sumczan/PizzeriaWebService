using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderStatusService
{
    Task<OrderStatusDTO> AddOrderStatusAsync(OrderStatusDTO orderStatusDTO);
    Task<OrderStatusDTO> GetOrderStatusByIdAsync(int id);
    Task<OrderStatusDTO> GetOrderStatusByNameAsync(string statusName);
    Task<IEnumerable<OrderStatusDTO>> GetOrderStatusesAsync();
    Task RemoveOrderStatusAsync(int id);
    Task<OrderStatusDTO> UpdateOrderStatusAsync(OrderStatusDTO orderStatusDTO);
}
