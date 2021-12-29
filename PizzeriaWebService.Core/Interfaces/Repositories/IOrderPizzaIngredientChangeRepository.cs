using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPizzaIngredientChangeRepository
{
    Task<OrderPizzaIngredientChange> AddOrderPizzaIngredientChangeAsync(OrderPizzaIngredientChange orderPizzaIngredientChange);
    Task<OrderPizzaIngredientChange> GetOrderPizzaIngredientChangeByIdAsync(int id);
    Task<IEnumerable<OrderPizzaIngredientChange>> GetOrderPizzaIngredientChangesAsync();
    Task<IEnumerable<OrderPizzaIngredientChange>> GetOrderPizzaIngredientChangesByOrderPizzaIdAsync(int orderPizzaId);
    Task RemoveOrderPizzaIngredientChangeAsync(int id);
    Task<OrderPizzaIngredientChange> UpdateOrderPizzaIngredientChangeAsync(OrderPizzaIngredientChange orderPizzaIngredientChange);
}
