using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class IngredientTypeService : IIngredientTypeService
{
    private readonly IIngredientTypeRepository _ingredientTypeRepository;
    private readonly IMapper _mapper;

    public IngredientTypeService(IIngredientTypeRepository ingredientTypeRepository, IMapper mapper)
    {
        _ingredientTypeRepository = ingredientTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IngredientTypeDTO>> GetIngredientTypesAsync()
    {
        var ingredientTypes = await _ingredientTypeRepository.GetIngredientTypesAsync().ConfigureAwait(false);
        var ingredientTypeDTOs = _mapper.Map<IEnumerable<IngredientTypeDTO>>(ingredientTypes);
        return ingredientTypeDTOs;
    }
    
    public async Task<IngredientTypeDTO> GetIngredientTypeByIdAsync(int id)
    {
        var ingredientType = await _ingredientTypeRepository.GetIngredientTypeByIdAsync(id).ConfigureAwait(false);
        var ingredientTypeDTO = _mapper.Map<IngredientTypeDTO>(ingredientType);
        return ingredientTypeDTO;
    }

    public async Task<IngredientTypeDTO> GetIngredientTypeByNameAsync(string ingredientTypeName)
    {
        var ingredientType = await _ingredientTypeRepository.GetIngredientTypeByNameAsync(ingredientTypeName).ConfigureAwait(false);
        var ingredientTypeDTO = _mapper.Map<IngredientTypeDTO>(ingredientType);
        return ingredientTypeDTO;
    }

    public async Task<IngredientTypeDTO> AddIngredientTypeAsync(IngredientTypeDTO ingredientTypeDTO)
    {
        var ingredientType = _mapper.Map<IngredientType>(ingredientTypeDTO);
        ingredientType = await _ingredientTypeRepository.AddIngredientTypeAsync(ingredientType).ConfigureAwait(false);
        ingredientTypeDTO = _mapper.Map<IngredientTypeDTO>(ingredientType);
        return ingredientTypeDTO;
    }

    public async Task<IngredientTypeDTO> UpdateIngredientTypeAsync(IngredientTypeDTO ingredientTypeDTO)
    {
        var ingredientType = _mapper.Map<IngredientType>(ingredientTypeDTO);
        ingredientType = await _ingredientTypeRepository.UpdateIngredientTypeAsync(ingredientType).ConfigureAwait(false);
        ingredientTypeDTO = _mapper.Map<IngredientTypeDTO>(ingredientType);
        return ingredientTypeDTO;
    }

    public async Task RemoveIngredientTypeAsync(int id)
    {
        await _ingredientTypeRepository.RemoveIngredientTypeAsync(id).ConfigureAwait(false);
    }
}
