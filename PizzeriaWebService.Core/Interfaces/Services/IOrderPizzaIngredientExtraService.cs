using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderPizzaIngredientExtraService
{
    Task<IEnumerable<OrderPizzaIngredientExtraDTO>> GetOrderPizzaIngredientExtrasAsync();
    Task<IEnumerable<OrderPizzaIngredientExtraDTO>> GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(int orderPizzaId);
    Task<OrderPizzaIngredientExtraDTO> GetOrderPizzaIngredientExtraByIdAsync(int id);
    Task RemoveOrderPizzaIngredientExtraAsync(int id);

    Task<OrderPizzaIngredientExtraDTO> AddOrderPizzaIngredientExtraAsync(
        OrderPizzaIngredientExtraDTO orderPizzaIngredientExtraDTO);

    Task<OrderPizzaIngredientExtraDTO> UpdateOrderPizzaIngredientExtraAsync(
        OrderPizzaIngredientExtraDTO orderPizzaIngredientExtraDTO);
}
