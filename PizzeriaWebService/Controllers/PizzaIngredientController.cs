using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PizzaIngredientController : ControllerBase
{
    private readonly IPizzaIngredientService _ingredientService;

    public PizzaIngredientController(IPizzaIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    // GET API/PizzaIngredient
    [HttpGet]
    public async Task<IActionResult> GetPizzaIngredientsAsync()
    {
        var result = await _ingredientService
            .GetPizzaIngredientsAsync()
            .ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/PizzaIngredient/Pizza/{pizzaId}
    [HttpGet("Pizza/{pizzaId}")]
    public async Task<IActionResult> GetPizzaIngredientsByPizzaIdAsync(int pizzaId)
    {
        var result = await _ingredientService
            .GetPizzaIngredientsByPizzaIdAsync(pizzaId)
            .ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/PizzaIngredient/Ingredient/{ingredientId}
    [HttpGet("Ingredient/{ingredientId}")]
    public async Task<IActionResult> GetPizzaIngredientsByIngredientIdAsync(int ingredientId)
    {
        var result = await _ingredientService
            .GetPizzaIngredientsByIngredientIdAsync(ingredientId)
            .ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/PizzaIngredient/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPizzaIngredientByIdAsync(int id)
    {
        var result = await _ingredientService
            .GetPizzaIngredientByIdAsync(id)
            .ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/PizzaIngredient/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePizzaIngredientAsync(int id)
    {
        await _ingredientService.RemovePizzaIngredientAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/PizzaIngredient
    [HttpPost]
    public async Task<IActionResult> AddPizzaIngredientAsync(PizzaIngredientDTO pizzaIngredientDTO)
    {
        var result = await _ingredientService
            .AddPizzaIngredientAsync(pizzaIngredientDTO)
            .ConfigureAwait(false);
        return CreatedAtAction(nameof(GetPizzaIngredientByIdAsync), new {id = result.Id}, result);
    }

    // PUT API/PizzaIngredient/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePizzaIngredientAsync(int id, PizzaIngredientDTO pizzaIngredientDTO)
    {
        pizzaIngredientDTO.Id = id;
        var result = await _ingredientService
            .UpdatePizzaIngredientAsync(pizzaIngredientDTO)
            .ConfigureAwait(false);
        return Ok(result);
    }
}
