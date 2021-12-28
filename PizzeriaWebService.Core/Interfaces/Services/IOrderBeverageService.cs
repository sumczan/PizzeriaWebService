using PizzeriaWebService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IOrderBeverageService
{
    Task<OrderBeverageDTO> AddOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO);
    Task<OrderBeverageDTO> GetOrderBeverageByIdAsync(int id);
    Task<IEnumerable<OrderBeverageDTO>> GetOrderBeveragesAsync();
    Task<IEnumerable<OrderBeverageDTO>> GetOrderBeveragesByOrderIdAsync(int orderId);
    Task RemoveOrderBeverageAsync(int id);
    Task<OrderBeverageDTO> UpdateOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO);
}
