using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class OrderPizzaIngredientChangeService : IOrderPizzaIngredientChangeService
{
    private readonly IOrderPizzaIngredientChangeRepository _ingredientChangeRepository;
    private readonly IMapper _mapper;

    public OrderPizzaIngredientChangeService(IOrderPizzaIngredientChangeRepository ingredientChangeRepository, IMapper mapper)
    {
        _ingredientChangeRepository = ingredientChangeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderPizzaIngredientChangeDTO>> GetOrderPizzaIngredientChangesAsync()
    {
        var ingredientChanges = await _ingredientChangeRepository
            .GetOrderPizzaIngredientChangesAsync()
            .ConfigureAwait(false);
        var ingredientChangeDTOs = _mapper.Map<IEnumerable<OrderPizzaIngredientChangeDTO>>(ingredientChanges);
        return ingredientChangeDTOs;
    }

    public async Task<IEnumerable<OrderPizzaIngredientChangeDTO>> GetOrderPizzaIngredientChangesByOrderPizzaIdAsync(int orderPizzaId)
    {
        var ingredientChanges = await _ingredientChangeRepository
            .GetOrderPizzaIngredientChangesByOrderPizzaIdAsync(orderPizzaId)
            .ConfigureAwait(false);
        var ingredientChangeDTOs = _mapper.Map<IEnumerable<OrderPizzaIngredientChangeDTO>>(ingredientChanges);
        return ingredientChangeDTOs;
    }

    public async Task<OrderPizzaIngredientChangeDTO> GetOrderPizzaIngredientChangeByIdAsync(int id)
    {
        var ingredientChange = await _ingredientChangeRepository
            .GetOrderPizzaIngredientChangeByIdAsync(id)
            .ConfigureAwait(false);
        var ingredientChangeDTO = _mapper.Map<OrderPizzaIngredientChangeDTO>(ingredientChange);
        return ingredientChangeDTO;
    }

    public async Task RemoveOrderPizzaIngredientChangeAsync(int id)
    {
        await _ingredientChangeRepository.RemoveOrderPizzaIngredientChangeAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderPizzaIngredientChangeDTO> AddOrderPizzaIngredientChangeAsync(
        OrderPizzaIngredientChangeDTO orderPizzaIngredientChangeDTO)
    {
        var ingredientChange = _mapper.Map<OrderPizzaIngredientChange>(orderPizzaIngredientChangeDTO);
        ingredientChange = await _ingredientChangeRepository
            .AddOrderPizzaIngredientChangeAsync(ingredientChange)
            .ConfigureAwait(false);
        orderPizzaIngredientChangeDTO = _mapper.Map<OrderPizzaIngredientChangeDTO>(ingredientChange);
        return orderPizzaIngredientChangeDTO;
    }

    public async Task<OrderPizzaIngredientChangeDTO> UpdateOrderPizzaIngredientChangeAsync(
        OrderPizzaIngredientChangeDTO orderPizzaIngredientChangeDTO)
    {
        var ingredientChange = _mapper.Map<OrderPizzaIngredientChange>(orderPizzaIngredientChangeDTO);
        ingredientChange = await _ingredientChangeRepository
            .UpdateOrderPizzaIngredientChangeAsync(ingredientChange)
            .ConfigureAwait(false);
        orderPizzaIngredientChangeDTO = _mapper.Map<OrderPizzaIngredientChangeDTO>(ingredientChange);
        return orderPizzaIngredientChangeDTO;
    }
}
