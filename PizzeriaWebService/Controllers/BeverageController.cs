using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}
