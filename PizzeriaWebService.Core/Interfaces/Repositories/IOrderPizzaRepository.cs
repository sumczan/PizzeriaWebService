using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPizzaRepository
{
    Task<OrderPizza> AddOrderPizzaAsync(OrderPizza orderPizza);
    Task<OrderPizza> GetOrderPizzaByIdAsync(int id);
    Task<IEnumerable<OrderPizza>> GetOrderPizzasAsync();
    Task<IEnumerable<OrderPizza>> GetOrderPizzasByOrderPlacedIdAsync(int orderPlacedId);
    Task RemoveOrderPizzaAsync(int id);
    Task<OrderPizza> UpdateOrderPizzaAsync(OrderPizza orderPizza);
}
