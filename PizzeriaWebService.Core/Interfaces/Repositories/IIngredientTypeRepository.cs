using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IIngredientTypeRepository
{
    Task<IngredientType> AddIngredientTypeAsync(IngredientType ingredientType);
    Task<IngredientType> GetIngredientTypeByIdAsync(int id);
    Task<IngredientType> GetIngredientTypeByNameAsync(string ingredientTypeName);
    Task<IEnumerable<IngredientType>> GetIngredientTypesAsync();
    Task RemoveIngredientTypeAsync(int id);
    Task<IngredientType> UpdateIngredientTypeAsync(IngredientType ingredientType);
}
