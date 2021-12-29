using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderAddressService
{
    Task<OrderAddressDTO> AddOrderAddressAsync(OrderAddressDTO orderAddressDTO);
    Task<OrderAddressDTO> GetOrderAddressByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderAddressDTO>> GetOrderAddressesAsync();
    Task<IEnumerable<OrderAddressDTO>> GetOrderAddressesByCityIdAsync(int cityId);
    Task RemoveOrderAddressAsync(int orderId);
    Task<OrderAddressDTO> UpdateOrderAddressAsync(OrderAddressDTO orderAddressDTO);
}
