using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IIngredientRepository
{
    Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<Ingredient> GetIngredientByNameAsync(string ingredientName);
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
    Task RemoveIngredientAsync(int id);
    Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
}
