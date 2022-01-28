using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderPizzaService _orderPizzaService;
    private readonly IOrderBeverageService _orderBeverageService;
    private readonly IMapper _mapper;
    private readonly PizzeriaDbContext _context;

    public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderBeverageService orderBeverageService, IOrderPizzaService orderPizzaService, PizzeriaDbContext context)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _orderBeverageService = orderBeverageService;
        _orderPizzaService = orderPizzaService;
        _context = context;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync().ConfigureAwait(false);
        var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
        return orderDTOs;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersByOrderStatusIdAsync(int orderStatusId)
    {
        var orders = await _orderRepository.GetOrdersByOrderStatusIdAsync(orderStatusId).ConfigureAwait(false);
        var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
        return orderDTOs;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersByOrderTypeIdAsync(int orderTypeId)
    {
        var orders = await _orderRepository.GetOrdersByOrderTypeIdAsync(orderTypeId).ConfigureAwait(false);
        var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
        return orderDTOs;
    }

    public async Task<OrderDTO> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id).ConfigureAwait(false);
        var orderDTO = _mapper.Map<OrderDTO>(order);
        return orderDTO;
    }

    public async Task RemoveOrderAsync(int id)
    {
        await _orderRepository.RemoveOrderAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
    {
        orderDTO.OrderTime = DateTime.Now;
        orderDTO = CalculateOrderPrice(orderDTO);

        var order = _mapper.Map<OrderPlaced>(orderDTO);
        try
        {
            await using var dbTransaction = await _context.Database.BeginTransactionAsync();
            order = await _orderRepository.AddOrderAsync(order).ConfigureAwait(false);

            orderDTO.Id = order.Id;
            if (orderDTO.OrderAddress is not null) 
                orderDTO.OrderAddress.OrderID = orderDTO.Id;
            orderDTO.OrderPizzas?.ToList().ForEach(x => x.OrderId = orderDTO.Id);
            orderDTO.OrderBeverages?.ToList().ForEach(x => x.OrderId = orderDTO.Id);

            await Task.WhenAll(AddOrderPizzas(orderDTO), AddOrderBeverages(orderDTO)).ConfigureAwait(false);

            await dbTransaction.CommitAsync();
        }
        catch (PizzeriaWebServiceException ex)
        {
            throw new PizzeriaWebServiceException("Problem occurred while adding new order", ex);
        }
        order = await _orderRepository.GetOrderByIdAsync(order.Id).ConfigureAwait(false);
        orderDTO = _mapper.Map<OrderDTO>(order);
        return orderDTO;
    }

    public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO)
    {
        orderDTO = CalculateOrderPrice(orderDTO);
        var orderToUpdate = await _orderRepository.GetOrderByIdAsync(orderDTO.Id).ConfigureAwait(false);
        var orderToUpdateDTO = _mapper.Map<OrderDTO>(orderToUpdate);
    }

    private static OrderDTO CalculateOrderPrice(OrderDTO orderDTO)
    {
        orderDTO.OrderPrice = decimal.Zero;
        if (orderDTO.OrderPizzas is not null && orderDTO.OrderPizzas.Any())
        {
            foreach (var orderPizzaDTO in orderDTO.OrderPizzas)
            {
                orderPizzaDTO.PizzaPrice = decimal.Zero;
                if (orderPizzaDTO.PizzaIngredientExtras is not null && orderPizzaDTO.PizzaIngredientExtras.Any())
                {
                    orderPizzaDTO.PizzaIngredientExtras
                        .ToList()
                        .ForEach(x=>x.ExtraIngredientPrice=x.ExtraIngredient.IngredientPrice*orderPizzaDTO.PizzaSize.PriceMultiplier);
                    orderPizzaDTO.PizzaPrice = orderPizzaDTO.PizzaIngredientExtras.Sum(x => x.ExtraIngredientPrice);
                }
                orderPizzaDTO.PizzaPrice += orderPizzaDTO.Pizza.PizzaPrice * orderPizzaDTO.PizzaSize.PriceMultiplier;
                orderDTO.OrderPrice += orderPizzaDTO.PizzaPrice;
            }
        }

        if (orderDTO.OrderBeverages is not null && orderDTO.OrderBeverages.Any())
        {
            orderDTO.OrderPrice += orderDTO.OrderBeverages.Sum(x => x.BeverageDTO.BeveragePrice);
        }

        return orderDTO;
    }

    private async Task AddOrderPizzas(OrderDTO orderDTO)
    {
        if (orderDTO.OrderPizzas is not null)
        {
            var taskList = orderDTO.OrderPizzas
                .Select(orderPizza => _orderPizzaService.AddOrderPizzaAsync(orderPizza))
                .Cast<Task>()
                .ToList();
            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }

    private async Task AddOrderBeverages(OrderDTO orderDTO)
    {
        if (orderDTO.OrderBeverages is not null)
        {
            var taskList = orderDTO.OrderBeverages
                .Select(orderBeverage => _orderBeverageService.AddOrderBeverageAsync(orderBeverage))
                .Cast<Task>()
                .ToList();
            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
