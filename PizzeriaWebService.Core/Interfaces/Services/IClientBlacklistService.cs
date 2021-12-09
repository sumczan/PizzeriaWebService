using PizzeriaWebService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IClientBlacklistService
{
    Task<ClientBlacklistDTO> AddClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO);
    Task<ClientBlacklistDTO> GetClientBlacklistByIdAsync(int id);
    Task<IEnumerable<ClientBlacklistDTO>> GetClientBlacklistsAsync();
    Task RemoveClientBlacklistAsync(int id);
    Task<ClientBlacklistDTO> UpdateClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO);
}
