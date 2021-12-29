using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderTypeRepository
{
    Task<OrderType> AddOrderTypeAsync(OrderType orderType);
    Task<OrderType> GetOrderTypeByIdAsync(int id);
    Task<OrderType> GetOrderTypeByNameAsync(string orderTypeName);
    Task<IEnumerable<OrderType>> GetOrderTypesAsync();
    Task RemoveOrderTypeAsync(int id);
    Task<OrderType> UpdateOrderTypeAsync(OrderType orderType);
}
