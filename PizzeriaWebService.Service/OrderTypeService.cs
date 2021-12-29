using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class OrderTypeService : IOrderTypeService
{
    private readonly IOrderTypeRepository _orderTypeRepository;
    private readonly IMapper _mapper;

    public OrderTypeService(IOrderTypeRepository orderTypeRepository, IMapper mapper)
    {
        _orderTypeRepository = orderTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderTypeDTO>> GetOrderTypesAsync()
    {
        var orderTypes = await _orderTypeRepository.GetOrderTypesAsync().ConfigureAwait(false);
        var orderTypeDTOs = _mapper.Map<IEnumerable<OrderTypeDTO>>(orderTypes);
        return orderTypeDTOs;
    }

    public async Task<OrderTypeDTO> GetOrderTypeByIdAsync(int id)
    {
        var orderType = await _orderTypeRepository.GetOrderTypeByIdAsync(id).ConfigureAwait(false);
        var orderTypeDTO = _mapper.Map<OrderTypeDTO>(orderType);
        return orderTypeDTO;
    }

    public async Task<OrderTypeDTO> GetOrderTypeByNameAsync(string typeName)
    {
        var orderType = await _orderTypeRepository.GetOrderTypeByNameAsync(typeName).ConfigureAwait(false);
        var orderTypeDTO = _mapper.Map<OrderTypeDTO>(orderType);
        return orderTypeDTO;
    }

    public async Task RemoveOrderTypeAsync(int id)
    {
        await _orderTypeRepository.RemoveOrderTypeAsync(id).ConfigureAwait(false);
    }

    public async Task<OrderTypeDTO> AddOrderTypeAsync(OrderTypeDTO orderTypeDTO)
    {
        var orderType = _mapper.Map<OrderType>(orderTypeDTO);
        orderType = await _orderTypeRepository.AddOrderTypeAsync(orderType).ConfigureAwait(false);
        orderTypeDTO = _mapper.Map<OrderTypeDTO>(orderType);
        return orderTypeDTO;
    }

    public async Task<OrderTypeDTO> UpdateOrderTypeAsync(OrderTypeDTO orderTypeDTO)
    {
        var orderType = _mapper.Map<OrderType>(orderTypeDTO);
        orderType = await _orderTypeRepository.UpdateOrderTypeAsync(orderType).ConfigureAwait(false);
        orderTypeDTO = _mapper.Map<OrderTypeDTO>(orderType);
        return orderTypeDTO;
    }
}
