using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IIngredientTypeService
{
    Task<IngredientTypeDTO> AddIngredientTypeAsync(IngredientTypeDTO ingredientTypeDTO);
    Task<IngredientTypeDTO> GetIngredientTypeByIdAsync(int id);
    Task<IngredientTypeDTO> GetIngredientTypeByNameAsync(string ingredientTypeName);
    Task<IEnumerable<IngredientTypeDTO>> GetIngredientTypesAsync();
    Task RemoveIngredientTypeAsync(int id);
    Task<IngredientTypeDTO> UpdateIngredientTypeAsync(IngredientTypeDTO ingredientTypeDTO);
}
