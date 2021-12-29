using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IClientBlacklistRepository
{
    Task<ClientBlacklist> AddClientBlacklistAsync(ClientBlacklist clientBlacklist);
    Task<IEnumerable<ClientBlacklist>> GetClientBlacklistAsync();
    Task<ClientBlacklist> GetClientBlacklistByIdAsync(int id);
    Task RemoveClientBlacklistAsync(int id);
    Task<ClientBlacklist> UpdateClientBlacklistAsync(ClientBlacklist clientBlacklist);
}
