using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    // GET API/Ingredient
    [HttpGet]
    public async Task<IActionResult> GetIngredientsAsync()
    {
        var result = await _ingredientService.GetIngredientsAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/Ingredient/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientByIdAsync(int id)
    {
        var result = await _ingredientService.GetIngredientByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/Ingredient/name/{ingredientName}
    [HttpGet("name/{ingredientName}")]
    public async Task<IActionResult> GetIngredientByNameAsync(string ingredientName)
    {
        var result = await _ingredientService.GetIngredientByNameAsync(ingredientName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/Ingredient/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveIngredientAsync(int id)
    {
        await _ingredientService.RemoveIngredientAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/Ingredient
    [HttpPost]
    public async Task<IActionResult> AddIngredientAsync(IngredientDTO ingredientDTO)
    {
        var result = await _ingredientService.AddIngredientAsync(ingredientDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetIngredientByIdAsync), new { id = result.Id }, result);
    }

    // PUT API/Ingredient/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIngredientAsync(int id, IngredientDTO ingredientDTO)
    {
        ingredientDTO.Id = id;
        var result = await _ingredientService.UpdateIngredientAsync(ingredientDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
