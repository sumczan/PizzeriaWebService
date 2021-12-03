using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IIngredientTypeRepository
{
    Task<IngredientType> AddIngredientTypeAsync(IngredientType ingredientType);
    Task<IngredientType> GetIngredientTypeByIdAsync(int id);
    Task<IngredientType> GetIngredientTypeByNameAsync(string ingredientTypeName);
    Task<IEnumerable<IngredientType>> GetIngredientTypesAsync();
    Task<IEnumerable<IngredientType>> GetIngredientTypesDairyAsync();
    Task<IEnumerable<IngredientType>> GetIngredientTypesGlutenFreeAsync();
    Task<IEnumerable<IngredientType>> GetIngredientTypesMeatAsync();
    Task<IEnumerable<IngredientType>> GetIngredientTypesVeganAsync();
    Task<IEnumerable<IngredientType>> GetIngredientTypesVegetableAsync();
    Task RemoveIngredientTypeAsync(int id);
    Task<IngredientType> UpdateIngredientTypeAsync(IngredientType ingredientType);
}
