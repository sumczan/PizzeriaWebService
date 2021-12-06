using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
