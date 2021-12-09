using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.DTOs;
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

    // GET API/ClientBlacklist
    [HttpGet]
    public async Task<IActionResult> GetClientBlacklistsAsync()
    {
        var result = await _clientBlacklistService.GetClientBlacklistsAsync().ConfigureAwait(false);
        return Ok(result);
    }

    // GET API/ClientBlacklist/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientBlacklistByIdAsync(int id)
    {
        var result = await _clientBlacklistService.GetClientBlacklistByIdAsync(id).ConfigureAwait(false);
        return Ok(result);
    }

    // POST API/ClientBlacklist
    [HttpPost]
    public async Task<IActionResult> AddClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO)
    {
        var result = await _clientBlacklistService.AddClientBlacklistAsync(clientBlacklistDTO).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetClientBlacklistByIdAsync), new { id = result.Id }, result);
    }

    // PUT API/ClientBlacklist/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClientBlacklistAsync(int id, ClientBlacklistDTO clientBlacklistDTO)
    {
        clientBlacklistDTO.Id = id;
        var result = await _clientBlacklistService.UpdateClientBlacklistAsync(clientBlacklistDTO).ConfigureAwait(false);
        return Ok(result);
    }

    // DELETE API/ClientBlacklist/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveClientBlacklistAsync(int id)
    {
        await _clientBlacklistService.RemoveClientBlacklistAsync(id).ConfigureAwait(false);
        return Ok();
    }
}
