using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    // GET API/Pizza
    [HttpGet]
    public async Task<IActionResult> GetPizzasAsync()
    {
        var result = await _pizzaService.GetPizzasAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/Pizza/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPizzaByIdAsync(int id)
    {
        var result = await _pizzaService.GetPizzaByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/Pizza/Name/{pizzaName}
    [HttpGet("name/{pizzaName}")]
    public async Task<IActionResult> GetPizzaByNameAsync(string pizzaName)
    {
        var result = await _pizzaService.GetPizzaByNameAsync(pizzaName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/Pizza/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePizzaAsync(int id)
    {
        await _pizzaService.RemovePizzaAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/Pizza
    [HttpPost]
    public async Task<IActionResult> AddPizzaAsync(PizzaDTO pizzaDTO)
    {
        var result = await _pizzaService.AddPizzaAsync(pizzaDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetPizzaByIdAsync), new {id = result.Id}, result);
    }

    // PUT API/Pizza/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePizzaAsync(PizzaDTO pizzaDTO)
    {
        var result = await _pizzaService.UpdatePizzaAsync(pizzaDTO).ConfigureAwait(false);
        return Ok(pizzaDTO);
    }
}
