using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class OrderAddressService : IOrderAddressService
{
    private readonly IOrderAddressRepository _orderAddressRepoistory;
    private readonly IMapper _mapper;

    public OrderAddressService(IOrderAddressRepository orderAddressRepoistory, IMapper mapper)
    {
        _orderAddressRepoistory = orderAddressRepoistory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderAddressDTO>> GetOrderAddressesAsync()
    {
        var orderAddresses = await _orderAddressRepoistory.GetOrderAddressesAsync().ConfigureAwait(false);
        var orderAddressDTOs = _mapper.Map<IEnumerable<OrderAddressDTO>>(orderAddresses);
        return orderAddressDTOs;
    }

    public async Task<IEnumerable<OrderAddressDTO>> GetOrderAddressesByCityIdAsync(int cityId)
    {
        var orderAddresses = await _orderAddressRepoistory.GetOrderAddressesByCityIdAsync(cityId).ConfigureAwait(false);
        var orderAddressDTOs = _mapper.Map<IEnumerable<OrderAddressDTO>>(orderAddresses);
        return orderAddressDTOs;
    }

    public async Task<OrderAddressDTO> GetOrderAddressByOrderIdAsync(int orderId)
    {
        var orderAddress = await _orderAddressRepoistory.GetOrderAddressByOrderIdAsync(orderId).ConfigureAwait(false);
        var orderAddressDTO = _mapper.Map<OrderAddressDTO>(orderAddress);
        return orderAddressDTO;
    }

    public async Task RemoveOrderAddressAsync(int orderId)
    {
        await _orderAddressRepoistory.RemoveOrderAddressAsync(orderId).ConfigureAwait(false);
    }

    public async Task<OrderAddressDTO> AddOrderAddressAsync(OrderAddressDTO orderAddressDTO)
    {
        var orderAddress = _mapper.Map<OrderAddress>(orderAddressDTO);
        orderAddress = await _orderAddressRepoistory.AddOrderAddressAsync(orderAddress).ConfigureAwait(false);
        orderAddressDTO = _mapper.Map<OrderAddressDTO>(orderAddress);
        return orderAddressDTO;
    }

    public async Task<OrderAddressDTO> UpdateOrderAddressAsync(OrderAddressDTO orderAddressDTO)
    {
        var orderAddress = _mapper.Map<OrderAddress>(orderAddressDTO);
        orderAddress = await _orderAddressRepoistory.UpdateOrderAddressAsync(orderAddress).ConfigureAwait(false);
        orderAddressDTO = _mapper.Map<OrderAddressDTO>(orderAddress);
        return orderAddressDTO;
    }
}
