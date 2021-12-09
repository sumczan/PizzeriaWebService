using PizzeriaWebService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
