using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPlacedRepository
{
    Task<OrderPlaced> AddOrderPlacedAsync(OrderPlaced orderPlaced);
    Task<OrderPlaced> GetOrderPlacedByIdAsync(int id);
    Task<IEnumerable<OrderPlaced>> GetOrderPlacedsAsync();
    Task<IEnumerable<OrderPlaced>> GetOrderPlacedsByOrderStatusIdAsync(int orderStatusId);
    Task<IEnumerable<OrderPlaced>> GetOrderPlacedsByOrderTypeIdAsync(int orderTypeId);
    Task RemoveOrderPlacedAsync(int id);
    Task<OrderPlaced> UpdateOrderPlacedAsync(OrderPlaced orderPlaced);
}
