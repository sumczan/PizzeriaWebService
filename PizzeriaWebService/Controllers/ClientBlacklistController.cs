using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Controllers;
[Route("API/[controller]")]
[ApiController]
public class ClientBlacklistController : ControllerBase
{
    private readonly IClientBlacklistService _clientBlacklistService;

    public ClientBlacklistController(IClientBlacklistService clientBlacklistService)
    {
        _clientBlacklistService = clientBlacklistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientBlacklistsAsync()
    {
        var result = await _clientBlacklistService.GetClientBlacklistsAsync().ConfigureAwait(false);
        return Ok(result);
    }

}
