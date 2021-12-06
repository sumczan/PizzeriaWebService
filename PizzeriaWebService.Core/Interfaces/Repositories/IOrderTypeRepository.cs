using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
