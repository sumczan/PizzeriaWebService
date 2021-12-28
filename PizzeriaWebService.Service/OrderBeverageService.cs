using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Service;

public class OrderBeverageService : IOrderBeverageService
{
    private readonly IOrderBeverageRepository _orderBeverageRepository;
    private readonly IMapper _mapper;

    public OrderBeverageService(IOrderBeverageRepository orderBeverageRepository, IMapper mapper)
    {
        _orderBeverageRepository = orderBeverageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderBeverageDTO>> GetOrderBeveragesAsync()
    {
        var orderBeverages = await _orderBeverageRepository.GetOrderBeveragesAsync().ConfigureAwait(false);
        var orderBeverageDTOs = _mapper.Map<IEnumerable<OrderBeverageDTO>>(orderBeverages);
        return orderBeverageDTOs;
    }

    public async Task<IEnumerable<OrderBeverageDTO>> GetOrderBeveragesByOrderIdAsync(int orderId)
    {
        var orderBeverages = await _orderBeverageRepository.GetOrderBeveragesByOrderIdAsync(orderId).ConfigureAwait(false);
        var orderBeverageDTOs = _mapper.Map<IEnumerable<OrderBeverageDTO>>(orderBeverages);
        return orderBeverageDTOs;
    }

    public async Task<OrderBeverageDTO> GetOrderBeverageByIdAsync(int id)
    {
        var orderBeverage = await _orderBeverageRepository.GetOrderBeverageByIdAsync(id).ConfigureAwait(false);
        var orderBeverageDTO = _mapper.Map<OrderBeverageDTO>(orderBeverage);
        return orderBeverageDTO;
    }

    public async Task RemoveOrderBeverageAsync(int id)
    {
        await _orderBeverageRepository.RemoveOrderBeverageAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderBeverageDTO> AddOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO)
    {
        var orderBeverage = _mapper.Map<OrderBeverage>(orderBeverageDTO);
        orderBeverage = await _orderBeverageRepository.AddOrderBeverageAsync(orderBeverage).ConfigureAwait(false);
        orderBeverageDTO = _mapper.Map<OrderBeverageDTO>(orderBeverage);
        return orderBeverageDTO;
    }

    public async Task<OrderBeverageDTO> UpdateOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO)
    {
        var orderBeverage = _mapper.Map<OrderBeverage>(orderBeverageDTO);
        orderBeverage = await _orderBeverageRepository.UpdateOrderBeverageAsync(orderBeverage).ConfigureAwait(false);
        orderBeverageDTO = _mapper.Map<OrderBeverageDTO>(orderBeverage);
        return orderBeverageDTO;
    }
}
