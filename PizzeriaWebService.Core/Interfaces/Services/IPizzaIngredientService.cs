using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IPizzaIngredientService
{
    Task<IEnumerable<PizzaIngredientDTO>> GetPizzaIngredientsAsync();
    Task<IEnumerable<PizzaIngredientDTO>> GetPizzaIngredientsByPizzaIdAsync(int pizzaId);
    Task<IEnumerable<PizzaIngredientDTO>> GetPizzaIngredientsByIngredientIdAsync(int ingredientId);
    Task<PizzaIngredientDTO> GetPizzaIngredientByIdAsync(int id);
    Task RemovePizzaIngredientAsync(int id);
    Task<PizzaIngredientDTO> AddPizzaIngredientAsync(PizzaIngredientDTO pizzaIngredientDTO);
    Task<PizzaIngredientDTO> UpdatePizzaIngredientAsync(PizzaIngredientDTO pizzaIngredientDTO);
}
