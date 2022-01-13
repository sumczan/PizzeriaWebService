using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderPizzaController : ControllerBase
{
    private readonly IOrderPizzaService _orderPizzaService;

    public OrderPizzaController(IOrderPizzaService orderPizzaService)
    {
        _orderPizzaService = orderPizzaService;
    }

    // GET API/OrderPizza
    [HttpGet]
    public async Task<IActionResult> GetOrderPizzasAsync()
    {
        var result = await _orderPizzaService.GetOrderPizzasAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // POST API/OrderPizza
    [HttpPost]
    public async Task<IActionResult> AddOrderPizzaAsync(OrderPizzaDTO orderPizzaDTO)
    {
        var result = await _orderPizzaService.AddOrderPizzaAsync(orderPizzaDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
