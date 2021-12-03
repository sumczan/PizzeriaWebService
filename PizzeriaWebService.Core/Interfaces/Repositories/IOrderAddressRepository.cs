using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderAddressRepository
{
    Task<OrderAddress> AddOrderAddressAsync(OrderAddress orderAddress);
    Task<OrderAddress> GetOrderAddressByOrderIdAsync(int orderPlacedId);
    Task<IEnumerable<OrderAddress>> GetOrderAddressesAsync();
    Task<IEnumerable<OrderAddress>> GetOrderAddressesAsyncByCityIdAsync(int cityId);
    Task RemoveOrderAddressAsync(int orderPlacedId);
    Task<OrderAddress> UpdateOrderAddressAsync(OrderAddress orderAddress);
}
