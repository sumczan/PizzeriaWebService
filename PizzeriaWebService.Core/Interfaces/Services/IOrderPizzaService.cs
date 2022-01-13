using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderPizzaService
{
    Task<IEnumerable<OrderPizzaDTO>> GetOrderPizzasAsync();
    Task<IEnumerable<OrderPizzaDTO>> GetOrderPizzasByOrderIdAsync(int orderId);
    Task<OrderPizzaDTO> GetOrderPizzaByIdAsync(int id);
    Task RemoveOrderPizzaAsync(int id);
    Task<OrderPizzaDTO> AddOrderPizzaAsync(OrderPizzaDTO orderPizzaDTO);
    Task<OrderPizzaDTO> UpdateOrderPizzaAsync(OrderPizzaDTO orderPizzaDTO);
}
