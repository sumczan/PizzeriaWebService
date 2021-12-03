using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
