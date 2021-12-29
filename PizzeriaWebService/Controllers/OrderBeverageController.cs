using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderBeverageController : ControllerBase
{
    private readonly IOrderBeverageService _orderBeverageService;

    public OrderBeverageController(IOrderBeverageService orderBeverageService)
    {
        _orderBeverageService = orderBeverageService;
    }

    // GET API/OrderBeverage
    [HttpGet]
    public async Task<IActionResult> GetOrderBeveragesAsync()
    {
        var result = await _orderBeverageService.GetOrderBeveragesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderBeverage/Order/{orderId}
    [HttpGet("Order/{orderId}")]
    public async Task<IActionResult> GetOrderBeveragesByOrderIdAsync(int orderId)
    {
        var result = await _orderBeverageService.GetOrderBeveragesByOrderIdAsync(orderId).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderBeverage/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderBeverageByIdAsync(int id)
    {
        var result = await _orderBeverageService.GetOrderBeverageByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/OrderBeverage/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> RemoveOrderBeverageAsync(int id)
    {
        await _orderBeverageService.RemoveOrderBeverageAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/OrderBeverage
    [HttpPost]
    public async Task<IActionResult> AddOrderBeverageAsync(OrderBeverageDTO orderBeverageDTO)
    {
        var result = await _orderBeverageService.AddOrderBeverageAsync(orderBeverageDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetOrderBeverageByIdAsync), new { id = orderBeverageDTO.Id }, result);
    }

    // PUT API/OrderBeverage/id
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateOrderBeverageAsync(int id, OrderBeverageDTO orderBeverageDTO)
    {
        orderBeverageDTO.Id = id;
        var result = await _orderBeverageService.UpdateOrderBeverageAsync(orderBeverageDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
