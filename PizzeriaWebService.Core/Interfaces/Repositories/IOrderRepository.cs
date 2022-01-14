using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<OrderPlaced> AddOrderAsync(OrderPlaced order);
    Task<OrderPlaced> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderPlaced>> GetOrdersAsync();
    Task<IEnumerable<OrderPlaced>> GetOrdersByOrderStatusIdAsync(int orderStatusId);
    Task<IEnumerable<OrderPlaced>> GetOrdersByOrderTypeIdAsync(int orderTypeId);
    Task RemoveOrderAsync(int id);
    Task<OrderPlaced> UpdateOrderAsync(OrderPlaced order);
}
