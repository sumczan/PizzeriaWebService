using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetOrdersAsync();
    Task<IEnumerable<OrderDTO>> GetOrdersByOrderStatusIdAsync(int orderStatusId);
    Task<IEnumerable<OrderDTO>> GetOrdersByOrderTypeIdAsync(int orderTypeId);
    Task<OrderDTO> GetOrderByIdAsync(int id);
    Task RemoveOrderAsync(int id);
    Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO);
    Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO);
}
