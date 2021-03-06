using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderTypeService
{
    Task<OrderTypeDTO> AddOrderTypeAsync(OrderTypeDTO orderTypeDTO);
    Task<OrderTypeDTO> GetOrderTypeByIdAsync(int id);
    Task<OrderTypeDTO> GetOrderTypeByNameAsync(string typeName);
    Task<IEnumerable<OrderTypeDTO>> GetOrderTypesAsync();
    Task RemoveOrderTypeAsync(int id);
    Task<OrderTypeDTO> UpdateOrderTypeAsync(OrderTypeDTO orderTypeDTO);
}
