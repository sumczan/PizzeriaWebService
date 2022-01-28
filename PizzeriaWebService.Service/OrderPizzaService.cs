using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class OrderPizzaService : IOrderPizzaService
{
    private readonly IOrderPizzaRepository _orderPizzaRepository;
    private readonly IOrderPizzaIngredientChangeService _orderPizzaChangeService;
    private readonly IOrderPizzaIngredientExtraService _orderPizzaExtraService;
    private readonly IMapper _mapper;

    public OrderPizzaService(IOrderPizzaRepository orderPizzaRepository, IOrderPizzaIngredientChangeService orderPizzaChangeService, IOrderPizzaIngredientExtraService orderPizzaExtraService, IMapper mapper)
    {
        _orderPizzaRepository = orderPizzaRepository;
        _orderPizzaChangeService = orderPizzaChangeService;
        _orderPizzaExtraService = orderPizzaExtraService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderPizzaDTO>> GetOrderPizzasAsync()
    {
        var orderPizzas = await _orderPizzaRepository.GetOrderPizzasAsync().ConfigureAwait(false);
        var orderPizzaDTOs = _mapper.Map<IEnumerable<OrderPizzaDTO>>(orderPizzas);
        return orderPizzaDTOs;
    }

    public async Task<IEnumerable<OrderPizzaDTO>> GetOrderPizzasByOrderIdAsync(int orderId)
    {
        var orderPizzas = await _orderPizzaRepository.GetOrderPizzasByOrderPlacedIdAsync(orderId).ConfigureAwait(false);
        var orderPizzaDTOs = _mapper.Map<IEnumerable<OrderPizzaDTO>>(orderPizzas);
        return orderPizzaDTOs;
    }

    public async Task<OrderPizzaDTO> GetOrderPizzaByIdAsync(int id)
    {
        var orderPizza = await _orderPizzaRepository.GetOrderPizzaByIdAsync(id).ConfigureAwait(false);
        var orderPizzaDTO = _mapper.Map<OrderPizzaDTO>(orderPizza);
        return orderPizzaDTO;
    }

    public async Task RemoveOrderPizzaAsync(int id)
    {
        await _orderPizzaRepository.RemoveOrderPizzaAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderPizzaDTO> AddOrderPizzaAsync(OrderPizzaDTO orderPizzaDTO)
    {
        var orderPizza = _mapper.Map<OrderPizza>(orderPizzaDTO);
        orderPizza = await _orderPizzaRepository.AddOrderPizzaAsync(orderPizza).ConfigureAwait(false);
        orderPizzaDTO.Id = orderPizza.Id;
        
        orderPizzaDTO.PizzaIngredientExtras?.ToList().ForEach(x=>x.OrderPizzaId=orderPizzaDTO.Id);
        orderPizzaDTO.PizzaIngredientChanges?.ToList().ForEach(x=>x.OrderPizzaId=orderPizzaDTO.Id);

        await Task.WhenAll(
            AddOrderPizzaIngredientChangesAsync(orderPizzaDTO),
            AddOrderPizzaIngredientExtrasAsync(orderPizzaDTO)
            )
            .ConfigureAwait(false);
        
        orderPizza = await _orderPizzaRepository.GetOrderPizzaByIdAsync(orderPizza.Id).ConfigureAwait(false);
        orderPizzaDTO = _mapper.Map<OrderPizzaDTO>(orderPizza);
        
        return orderPizzaDTO;
    }

    public async Task<OrderPizzaDTO> UpdateOrderPizzaAsync(OrderPizzaDTO orderPizzaDTO)
    {
        throw new NotImplementedException();
    }

    private async Task AddOrderPizzaIngredientChangesAsync(OrderPizzaDTO orderPizzaDTO)
    {
        if (orderPizzaDTO.PizzaIngredientChanges is not null)
        {
            var taskList = orderPizzaDTO.PizzaIngredientChanges
                .Select(ingredientChange => _orderPizzaChangeService.AddOrderPizzaIngredientChangeAsync(ingredientChange))
                .Cast<Task>()
                .ToList();
            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }

    private async Task AddOrderPizzaIngredientExtrasAsync(OrderPizzaDTO orderPizzaDTO)
    {
        if (orderPizzaDTO.PizzaIngredientExtras is not null)
        {
            var taskList = orderPizzaDTO.PizzaIngredientExtras
                .Select(ingredientExtra => _orderPizzaExtraService.AddOrderPizzaIngredientExtraAsync(ingredientExtra))
                .Cast<Task>()
                .ToList();
            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}