using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPizzaIngredientExtraRepository
{
    Task<OrderPizzaIngredientExtra> AddOrderPizzaIngredientExtraAsync(OrderPizzaIngredientExtra orderPizzaIngredientExtra);
    Task<OrderPizzaIngredientExtra> GetOrderPizzaIngredientExtraByIdAsync(int id);
    Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasAsync();
    Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(int orderPizzaId);
    Task RemoveOrderPizzaIngredientExtraAsync(int id);
    Task<OrderPizzaIngredientExtra> UpdateOrderPizzaIngredientExtraAsync(OrderPizzaIngredientExtra orderPizzaIngredientExtra);
}
