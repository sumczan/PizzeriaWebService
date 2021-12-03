using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderBeverageRepository
{
    Task<OrderBeverage> AddOrderBeverageAsync(OrderBeverage orderBeverage);
    Task<OrderBeverage> GetOrderBeverageByIdAsync(int id);
    Task<IEnumerable<OrderBeverage>> GetOrderBeveragesAsync();
    Task<IEnumerable<OrderBeverage>> GetOrderBeveragesByOrderIdAsync(int orderId);
    Task RemoveOrderBeverageAsync(int id);
    Task<OrderBeverage> UpdateOrderBeverageAsync(OrderBeverage orderBeverage);
}
