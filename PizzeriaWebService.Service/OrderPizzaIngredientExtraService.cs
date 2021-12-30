using System.Runtime.CompilerServices;
using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class OrderPizzaIngredientExtraService : IOrderPizzaIngredientExtraService
{
    private readonly IOrderPizzaIngredientExtraRepository _ingredientExtraRepository;
    private readonly IMapper _mapper;

    public OrderPizzaIngredientExtraService(IOrderPizzaIngredientExtraRepository ingredientExtraRepository, IMapper mapper)
    {
        _ingredientExtraRepository = ingredientExtraRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderPizzaIngredientExtraDTO>> GetOrderPizzaIngredientExtrasAsync()
    {
        var ingredientExtras = await _ingredientExtraRepository
            .GetOrderPizzaIngredientExtrasAsync()
            .ConfigureAwait(false);
        var ingredientExtraDTOs = _mapper.Map<IEnumerable<OrderPizzaIngredientExtraDTO>>(ingredientExtras);
        return ingredientExtraDTOs;
    }

    public async Task<IEnumerable<OrderPizzaIngredientExtraDTO>> GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(int orderPizzaId)
    {
        var ingredientExtras = await _ingredientExtraRepository
            .GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(orderPizzaId)
            .ConfigureAwait(false);
        var ingredientExtraDTOs = _mapper.Map<IEnumerable<OrderPizzaIngredientExtraDTO>>(ingredientExtras);
        return ingredientExtraDTOs;
    }

    public async Task<OrderPizzaIngredientExtraDTO> GetOrderPizzaIngredientExtraByIdAsync(int id)
    {
        var ingredientExtra = await _ingredientExtraRepository
            .GetOrderPizzaIngredientExtraByIdAsync(id)
            .ConfigureAwait(false);
        var ingredientExtraDTO = _mapper.Map<OrderPizzaIngredientExtraDTO>(ingredientExtra);
        return ingredientExtraDTO;
    }

    public async Task RemoveOrderPizzaIngredientExtraAsync(int id)
    {
        await _ingredientExtraRepository.RemoveOrderPizzaIngredientExtraAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderPizzaIngredientExtraDTO> AddOrderPizzaIngredientExtraAsync(
        OrderPizzaIngredientExtraDTO orderPizzaIngredientExtraDTO)
    {
        var ingredientExtra = _mapper.Map<OrderPizzaIngredientExtra>(orderPizzaIngredientExtraDTO);
        ingredientExtra = await _ingredientExtraRepository
            .AddOrderPizzaIngredientExtraAsync(ingredientExtra)
            .ConfigureAwait(false);
        orderPizzaIngredientExtraDTO = _mapper.Map<OrderPizzaIngredientExtraDTO>(ingredientExtra);
        return orderPizzaIngredientExtraDTO;
    }

    public async Task<OrderPizzaIngredientExtraDTO> UpdateOrderPizzaIngredientExtraAsync(
        OrderPizzaIngredientExtraDTO orderPizzaIngredientExtraDTO)
    {
        var ingredientExtra = _mapper.Map<OrderPizzaIngredientExtra>(orderPizzaIngredientExtraDTO);
        ingredientExtra = await _ingredientExtraRepository
            .UpdateOrderPizzaIngredientExtraAsync(ingredientExtra)
            .ConfigureAwait(false);
        orderPizzaIngredientExtraDTO = _mapper.Map<OrderPizzaIngredientExtraDTO>(ingredientExtra);
        return orderPizzaIngredientExtraDTO;
    }
}
