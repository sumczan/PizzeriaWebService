using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderTypeController : ControllerBase
{
    private readonly IOrderTypeService _orderTypeService;

    public OrderTypeController(IOrderTypeService orderTypeService)
    {
        _orderTypeService = orderTypeService;
    }

    // GET API/OrderType
    [HttpGet]
    public async Task<IActionResult> GetOrderTypesAsync()
    {
        var result = await _orderTypeService.GetOrderTypesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderType/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderTypeByIdAsync(int id)
    {
        var result = await _orderTypeService.GetOrderTypeByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderType/Name/{typeName}
    [HttpGet("name/{typeName}")]
    public async Task<IActionResult> GetOrderTypeByNameAsync(string typeName)
    {
        var result = await _orderTypeService.GetOrderTypeByNameAsync(typeName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/OrderType/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveOrderTypeAsync(int id)
    {
        await _orderTypeService.RemoveOrderTypeAsync(id).ConfigureAwait(false);
        return NoContent();
    }
    
    // POST API/OrderType
    [HttpPost]
    public async Task<IActionResult> AddOrderTypeAsync(OrderTypeDTO orderTypeDTO)
    {
        var result = await _orderTypeService.AddOrderTypeAsync(orderTypeDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetOrderTypeByIdAsync), new { id = orderTypeDTO.Id }, result);
    }

    // PUT API/OrderType/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderTypeAsync(int id, OrderTypeDTO orderTypeDTO)
    {
        orderTypeDTO.Id = id;
        var result = await _orderTypeService.UpdateOrderTypeAsync(orderTypeDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
