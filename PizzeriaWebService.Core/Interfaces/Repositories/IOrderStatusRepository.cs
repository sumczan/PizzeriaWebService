using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
