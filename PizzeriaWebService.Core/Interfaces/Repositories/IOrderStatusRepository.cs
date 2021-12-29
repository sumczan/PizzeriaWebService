using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderStatusRepository
{
    Task<OrderStatus> AddOrderStatusAsync(OrderStatus orderStatus);
    Task<OrderStatus> GetOrderStatusByIdAsync(int id);
    Task<OrderStatus> GetOrderStatusByNameAsync(string statusName);
    Task<IEnumerable<OrderStatus>> GetOrderStatusesAsync();
    Task RemoveOrderStatusAsync(int id);
    Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus);
}
