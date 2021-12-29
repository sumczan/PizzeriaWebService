using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderAddressRepository
{
    Task<OrderAddress> AddOrderAddressAsync(OrderAddress orderAddress);
    Task<OrderAddress> GetOrderAddressByOrderIdAsync(int orderPlacedId);
    Task<IEnumerable<OrderAddress>> GetOrderAddressesAsync();
    Task<IEnumerable<OrderAddress>> GetOrderAddressesByCityIdAsync(int cityId);
    Task RemoveOrderAddressAsync(int orderPlacedId);
    Task<OrderAddress> UpdateOrderAddressAsync(OrderAddress orderAddress);
}
