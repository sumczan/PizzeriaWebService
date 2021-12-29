using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderStatusController : ControllerBase
{
    private readonly IOrderStatusService _orderStatusService;

    public OrderStatusController(IOrderStatusService orderStatusService)
    {
        _orderStatusService = orderStatusService;
    }

    // GET API/OrderStatus
    [HttpGet]
    public async Task<IActionResult> GetOrderStatusesAsync()
    {
        var result = await _orderStatusService.GetOrderStatusesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderStatus/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderStatusByIdAsync(int id)
    {
        var result = await _orderStatusService.GetOrderStatusByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderStatus/name/{statusName}
    [HttpGet("name/{statusName}")]
    public async Task<IActionResult> GetOrderStatusByNameAsync(string statusName)
    {
        var result = await _orderStatusService.GetOrderStatusByNameAsync(statusName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/OrderStatus/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveOrderStatusAsync(int id)
    {
        await _orderStatusService.RemoveOrderStatusAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/OrderStatus
    [HttpPost]
    public async Task<IActionResult> AddOrderStatusAsync(OrderStatusDTO orderStatusDTO)
    {
        var result = await _orderStatusService.AddOrderStatusAsync(orderStatusDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetOrderStatusByIdAsync), new { id = orderStatusDTO.Id }, result);
    }

    // PUT API/OrderStatus/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderStatusAsync(int id, OrderStatusDTO orderStatusDTO)
    {
        orderStatusDTO.Id = id;
        var result = await _orderStatusService.UpdateOrderStatusAsync(orderStatusDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
