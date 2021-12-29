using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IClientBlacklistService
{
    Task<ClientBlacklistDTO> AddClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO);
    Task<ClientBlacklistDTO> GetClientBlacklistByIdAsync(int id);
    Task<IEnumerable<ClientBlacklistDTO>> GetClientBlacklistsAsync();
    Task RemoveClientBlacklistAsync(int id);
    Task<ClientBlacklistDTO> UpdateClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO);
}
