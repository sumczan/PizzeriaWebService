using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderPizzaIngredientChangeService
{
    Task<IEnumerable<OrderPizzaIngredientChangeDTO>> GetOrderPizzaIngredientChangesAsync();
    Task<IEnumerable<OrderPizzaIngredientChangeDTO>> GetOrderPizzaIngredientChangesByOrderPizzaIdAsync(int orderPizzaId);
    Task<OrderPizzaIngredientChangeDTO> GetOrderPizzaIngredientChangeByIdAsync(int id);
    Task RemoveOrderPizzaIngredientChangeAsync(int id);

    Task<OrderPizzaIngredientChangeDTO> AddOrderPizzaIngredientChangeAsync(
        OrderPizzaIngredientChangeDTO orderPizzaIngredientChangeDTO);

    Task<OrderPizzaIngredientChangeDTO> UpdateOrderPizzaIngredientChangeAsync(
        OrderPizzaIngredientChangeDTO orderPizzaIngredientChangeDTO);
}
