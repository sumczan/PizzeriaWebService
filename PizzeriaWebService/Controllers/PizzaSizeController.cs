using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PizzaSizeController : ControllerBase
{
    private readonly IPizzaSizeService _pizzaSizeService;

    public PizzaSizeController(IPizzaSizeService pizzaSizeService)
    {
        _pizzaSizeService = pizzaSizeService;
    }

    // GET API/PizzaSize
    [HttpGet]
    public async Task<IActionResult> GetPizzaSizesAsync()
    {
        var result = await _pizzaSizeService.GetPizzaSizesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/PizzaSize/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPizzaSizeByIdAsync(int id)
    {
        var result = await _pizzaSizeService.GetPizzaSizeByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/PizzaSize/name/{sizeName}
    [HttpGet("name/{sizeName}")]
    public async Task<IActionResult> GetPizzaSizeByNameAsync(string sizeName)
    {
        var result = await _pizzaSizeService.GetPizzaSizeByNameAsync(sizeName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/PizzaSize/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePizzaSizeAsync(int id)
    {
        await _pizzaSizeService.RemovePizzaSizeAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/PizzaSize
    [HttpPost]
    public async Task<IActionResult> AddPizzaSizeAsync(PizzaSizeDTO pizzaSizeDTO)
    {
        var result = await _pizzaSizeService.AddPizzaSizeAsync(pizzaSizeDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetPizzaSizeByIdAsync), new { id = result.Id }, result);
    }

    // PUT API/PizzaSize/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePizzaSizeAsync(int id, PizzaSizeDTO pizzaSizeDTO)
    {
        pizzaSizeDTO.Id = id;
        var result = await _pizzaSizeService.UpdatePizzaSizeDTO(pizzaSizeDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
