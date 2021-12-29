using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
    {
        _ingredientRepository = ingredientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IngredientDTO>> GetIngredientsAsync()
    {
        var ingredients = await _ingredientRepository.GetIngredientsAsync().ConfigureAwait(false);
        var ingredientDTOs = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients);
        return ingredientDTOs;
    }

    public async Task<IngredientDTO> GetIngredientByIdAsync(int id)
    {
        var ingredient = await _ingredientRepository.GetIngredientByIdAsync(id).ConfigureAwait(false);
        var ingredientDTO = _mapper.Map<IngredientDTO>(ingredient);
        return ingredientDTO;
    }

    public async Task<IngredientDTO> GetIngredientByNameAsync(string ingredientName)
    {
        var ingredient = await _ingredientRepository.GetIngredientByNameAsync(ingredientName).ConfigureAwait(false);
        var ingredientDTO = _mapper.Map<IngredientDTO>(ingredient);
        return ingredientDTO;
    }

    public async Task<IngredientDTO> AddIngredientAsync(IngredientDTO ingredientDTO)
    {
        var ingredient = _mapper.Map<Ingredient>(ingredientDTO);
        ingredient = await _ingredientRepository.AddIngredientAsync(ingredient).ConfigureAwait(false);
        ingredientDTO = _mapper.Map<IngredientDTO>(ingredient);
        return ingredientDTO;
    }

    public async Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO ingredientDTO)
    {
        var ingredient = _mapper.Map<Ingredient>(ingredientDTO);
        ingredient = await _ingredientRepository.UpdateIngredientAsync(ingredient).ConfigureAwait(false);
        ingredientDTO = _mapper.Map<IngredientDTO>(ingredient);
        return ingredientDTO;
    }

    public async Task RemoveIngredientAsync(int id)
    {
        await _ingredientRepository.RemoveIngredientAsync(id).ConfigureAwait(false);
    }
}
