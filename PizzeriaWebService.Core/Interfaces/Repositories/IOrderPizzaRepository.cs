using PizzeriaWebService.Core.EfModels;

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
