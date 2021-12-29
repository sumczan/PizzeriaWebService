using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IIngredientService
{
    Task<IngredientDTO> AddIngredientAsync(IngredientDTO ingredientDTO);
    Task<IngredientDTO> GetIngredientByIdAsync(int id);
    Task<IngredientDTO> GetIngredientByNameAsync(string ingredientName);
    Task<IEnumerable<IngredientDTO>> GetIngredientsAsync();
    Task RemoveIngredientAsync(int id);
    Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO ingredientDTO);
}
