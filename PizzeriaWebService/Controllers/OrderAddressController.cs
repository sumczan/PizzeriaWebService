using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderAddressController : ControllerBase
{
    private readonly IOrderAddressService _orderAddressService;

    public OrderAddressController(IOrderAddressService orderAddressService)
    {
        _orderAddressService = orderAddressService;
    }

    // GET API/OrderAddress
    [HttpGet]
    public async Task<IActionResult> GetOrderAddressesAsync()
    {
        var result = await _orderAddressService.GetOrderAddressesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderAddress/City/{cityId}
    [HttpGet("City/{cityId}")]
    public async Task<IActionResult> GetOrderAddressesByCityIdAsync(int cityId)
    {
        var result = await _orderAddressService.GetOrderAddressesByCityIdAsync(cityId).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/OrderAddress/{orderId}
    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderAddressByOrderIdAsync(int orderId)
    {
        var result = await _orderAddressService.GetOrderAddressByOrderIdAsync(orderId).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/OrderAddress/{orderId}
    [HttpDelete("{orderId}")]
    public async Task<IActionResult> RemoveOrderAddressAsync(int orderId)
    {
        await _orderAddressService.RemoveOrderAddressAsync(orderId).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/OrderAddress
    [HttpPost]
    public async Task<IActionResult> AddOrderAddressAsync(OrderAddressDTO orderAddressDTO)
    {
        var result = await _orderAddressService.AddOrderAddressAsync(orderAddressDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetOrderAddressByOrderIdAsync), new { orderId = result.OrderID }, result);
    }

    // PUT Api/OrderAddress/{orderId}
    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrderAddressAsync(int orderId, OrderAddressDTO orderAddressDTO)
    {
        orderAddressDTO.OrderID = orderId;
        var result = await _orderAddressService.UpdateOrderAddressAsync(orderAddressDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
