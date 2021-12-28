using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientTypeController : ControllerBase
{
    private readonly IIngredientTypeService _ingredientTypeService;

    public IngredientTypeController(IIngredientTypeService ingredientTypeService)
    {
        _ingredientTypeService = ingredientTypeService;
    }

    // GET API/IngredientType
    [HttpGet]
    public async Task<IActionResult> GetIngredientTypesAsync()
    {
        var result = await _ingredientTypeService.GetIngredientTypesAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/IngredientType/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientTypeByIdAsync(int id)
    {
        var result = await _ingredientTypeService.GetIngredientTypeByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/IngredientType/name{typeName}
    [HttpGet("name/{typeName}")]
    public async Task<IActionResult> GetIngredientTypeByNameAsync(string typeName)
    {
        var result = await _ingredientTypeService.GetIngredientTypeByNameAsync(typeName).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/IngredientType/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveIngredientTypeAsync(int id)
    {
        await _ingredientTypeService.RemoveIngredientTypeAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    // POST API/IngredientType
    [HttpPost]
    public async Task<IActionResult> AddIgredientTypeAsync(IngredientTypeDTO ingredientTypeDTO)
    {
        var result = await _ingredientTypeService.AddIngredientTypeAsync(ingredientTypeDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetIngredientTypeByIdAsync), new {id = result.Id}, result);
    }

    // PUT API/IngredientType/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIngredientTypeAsync(int id, IngredientTypeDTO ingredientTypeDTO)
    {
        ingredientTypeDTO.Id = id;
        var result = await _ingredientTypeService.UpdateIngredientTypeAsync(ingredientTypeDTO).ConfigureAwait(false);
        return Ok(result);
    }
}
