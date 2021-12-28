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

public class OrderStatusService : IOrderStatusService
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderStatusDTO>> GetOrderStatusesAsync()
    {
        var orderStatuses =  await _orderStatusRepository.GetOrderStatusesAsync().ConfigureAwait(false);
        var orderStatusDTOs = _mapper.Map<IEnumerable<OrderStatusDTO>>(orderStatuses);
        return orderStatusDTOs;
    }

    public async Task<OrderStatusDTO> GetOrderStatusByIdAsync(int id)
    {
        var orderStatus = await _orderStatusRepository.GetOrderStatusByIdAsync(id).ConfigureAwait(false);
        var orderStatusDTO = _mapper.Map<OrderStatusDTO>(orderStatus);
        return orderStatusDTO;
    }

    public async Task<OrderStatusDTO> GetOrderStatusByNameAsync(string statusName)
    {
        var orderStatus = await _orderStatusRepository.GetOrderStatusByNameAsync(statusName).ConfigureAwait(false);
        var orderStatusDTO = _mapper.Map<OrderStatusDTO>(orderStatus);
        return orderStatusDTO;
    }

    public async Task RemoveOrderStatusAsync(int id)
    {
        await _orderStatusRepository.RemoveOrderStatusAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderStatusDTO> AddOrderStatusAsync(OrderStatusDTO orderStatusDTO)
    {
        var orderStatus = _mapper.Map<OrderStatus>(orderStatusDTO);
        orderStatus = await _orderStatusRepository.AddOrderStatusAsync(orderStatus).ConfigureAwait(false);
        orderStatusDTO = _mapper.Map<OrderStatusDTO>(orderStatus);
        return orderStatusDTO;
    }

    public async Task<OrderStatusDTO> UpdateOrderStatusAsync(OrderStatusDTO orderStatusDTO)
    {
        var orderStatus = _mapper.Map<OrderStatus>(orderStatusDTO);
        orderStatus = await _orderStatusRepository.UpdateOrderStatusAsync(orderStatus).ConfigureAwait(false);
        orderStatusDTO = _mapper.Map<OrderStatusDTO>(orderStatus);
        return orderStatusDTO;
    }
}
