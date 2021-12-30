using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class PizzaIngredientService : IPizzaIngredientService
{
    private readonly IPizzaIngredientRepository _pizzaIngredientRepository;
    private readonly IMapper _mapper;

    public PizzaIngredientService(IPizzaIngredientRepository pizzaIngredientRepository, IMapper mapper)
    {
        _pizzaIngredientRepository = pizzaIngredientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PizzaIngredientDTO>> GetPizzaIngredientsAsync()
    {
        var pizzaIngredients = await _pizzaIngredientRepository
            .GetPizzaIngredientsAsync()
            .ConfigureAwait(false);
        var pizzaIngredientDTOs = _mapper.Map<IEnumerable<PizzaIngredientDTO>>(pizzaIngredients);
        return pizzaIngredientDTOs;
    }

    public async Task<IEnumerable<PizzaIngredientDTO>> GetPizzaIngredientsByPizzaIdAsync(int pizzaId)
    {
        var pizzaIngredients = await _pizzaIngredientRepository
            .GetPizzaIngredientsByPizzaIdAsync(pizzaId)
            .ConfigureAwait(false);
        var pizzaIngredientDTOs = _mapper.Map<IEnumerable<PizzaIngredientDTO>>(pizzaIngredients);
        return pizzaIngredientDTOs;
    }

    public async Task<IEnumerable<PizzaIngredientDTO>> GetPizzaIngredientsByIngredientIdAsync(int ingredientId)
    {
        var pizzaIngredients = await _pizzaIngredientRepository
            .GetPizzaIngredientsByIngredientIdAsync(ingredientId)
            .ConfigureAwait(false);
        var pizzaIngredientDTOs = _mapper.Map<IEnumerable<PizzaIngredientDTO>>(pizzaIngredients);
        return pizzaIngredientDTOs;
    }

    public async Task<PizzaIngredientDTO> GetPizzaIngredientByIdAsync(int id)
    {
        var pizzaIngredient = await _pizzaIngredientRepository
            .GetPizzaIngredientByIdAsync(id)
            .ConfigureAwait(false);
        var pizzaIngredientDTO = _mapper.Map<PizzaIngredientDTO>(pizzaIngredient);
        return pizzaIngredientDTO;
    }

    public async Task RemovePizzaIngredientAsync(int id)
    {
        await _pizzaIngredientRepository.RemovePizzaIngredientAsync(id).ConfigureAwait(false);
    }

    public async Task<PizzaIngredientDTO> AddPizzaIngredientAsync(PizzaIngredientDTO pizzaIngredientDTO)
    {
        var pizzaIngredient = _mapper.Map<PizzaIngredient>(pizzaIngredientDTO);
        pizzaIngredient = await _pizzaIngredientRepository
            .AddPizzaIngredientAsync(pizzaIngredient)
            .ConfigureAwait(false);
        pizzaIngredientDTO = _mapper.Map<PizzaIngredientDTO>(pizzaIngredient);
        return pizzaIngredientDTO;
    }

    public async Task<PizzaIngredientDTO> UpdatePizzaIngredientAsync(PizzaIngredientDTO pizzaIngredientDTO)
    {
        var pizzaIngredient = _mapper.Map<PizzaIngredient>(pizzaIngredientDTO);
        pizzaIngredient = await _pizzaIngredientRepository
            .UpdatePizzaIngredientAsync(pizzaIngredient)
            .ConfigureAwait(false);
        pizzaIngredientDTO = _mapper.Map<PizzaIngredientDTO>(pizzaIngredient);
        return pizzaIngredientDTO;
    }
}
