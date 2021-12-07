using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("API/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    // GET API/City
    [HttpGet]
    public async Task<IActionResult> GetCitiesAsync()
    {
        var result = await _cityService.GetCitiesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/City/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCityByIdAsync(int id)
    {
        var result = await _cityService.GetCityByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/City/Name/{cityName}
    [HttpGet("name/{cityName}")]
    public async Task<IActionResult> GetCityByNameAsync(string cityName)
    {
        var result = await _cityService.GetCityByNameAsync(cityName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/City/ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCityAsync(int id)
    {
        await _cityService.RemoveCityAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/City
    [HttpPost]
    public async Task<IActionResult> AddCityAsync(CityDTO cityDTO)
    {
        var result = await _cityService.AddCityAsync(cityDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetCityByIdAsync),new {id = result.Id}, result);
    }

    // PUT API/City
    [HttpPut]
    public async Task<IActionResult> UpdateCityAsync(CityDTO cityDTO)
    {
        var result = await _cityService.UpdateCityAsync(cityDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
