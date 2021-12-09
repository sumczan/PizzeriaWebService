using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class BeverageController : ControllerBase
{
    private readonly IBeverageService _beverageService;

    public BeverageController(IBeverageService beverageService)
    {
        _beverageService = beverageService;
    }

    // GET API/beverage
    [HttpGet]
    public async Task<IActionResult> GetBeveragesAsync()
    {
        var result = await _beverageService.GetBeveragesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/beverage/alcoholic
    [HttpGet("alcoholic")]
    public async Task<IActionResult> GetAlcoholicBeverages()
    {
        var result = await _beverageService.GetAlcoholicBeveragesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/beverage/nonalcoholic
    [HttpGet("nonalcoholic")]
    public async Task<IActionResult> GetNonAlcoholicBeverages()
    {
        var result = await _beverageService.GetNonAlcoholicBeveragesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // Get API/beverage/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBeverageByIdAsync(int id)
    {
        var result = await _beverageService.GetBeverageByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // Delete API/beverage/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBeverageAsync(int id)
    {
        await _beverageService.RemoveBeverageAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/beverage
    [HttpPost]
    public async Task<IActionResult> AddBeverageAsync(BeverageDTO beverageDTO)
    {
        var result = await _beverageService.AddBeverageAsync(beverageDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetBeverageByIdAsync), new {id = result.Id}, result);
    }

    // PUT API/beverage/id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBeverageAsync(int id, BeverageDTO beverageDTO)
    {
        beverageDTO.Id = id;
        var result = await _beverageService.UpdateBeverageAsync(beverageDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
