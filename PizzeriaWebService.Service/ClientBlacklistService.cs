using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class ClientBlacklistService : IClientBlacklistService
{
    private readonly IClientBlacklistRepository _clientBlacklistRepository;
    private readonly IMapper _mapper;

    public ClientBlacklistService(IClientBlacklistRepository clientBlacklistRepository, IMapper mapper)
    {
        _clientBlacklistRepository = clientBlacklistRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientBlacklistDTO>> GetClientBlacklistsAsync()
    {
        var clientBlacklists = await _clientBlacklistRepository.GetClientBlacklistAsync().ConfigureAwait(false);
        var clientBlacklistDTOs = _mapper.Map<IEnumerable<ClientBlacklistDTO>>(clientBlacklists);
        return clientBlacklistDTOs;
    }

    public async Task<ClientBlacklistDTO> GetClientBlacklistByIdAsync(int id)
    {
        var clientBlacklist = await _clientBlacklistRepository.GetClientBlacklistByIdAsync(id).ConfigureAwait(false);
        var clientBlacklistDTO = _mapper.Map<ClientBlacklistDTO>(clientBlacklist);
        return clientBlacklistDTO;
    }

    public async Task<ClientBlacklistDTO> AddClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO)
    {
        var clientBlacklist = _mapper.Map<ClientBlacklist>(clientBlacklistDTO);
        clientBlacklist = await _clientBlacklistRepository.AddClientBlacklistAsync(clientBlacklist).ConfigureAwait(false);
        clientBlacklistDTO = _mapper.Map<ClientBlacklistDTO>(clientBlacklist);
        return clientBlacklistDTO;
    }

    public async Task RemoveClientBlacklistAsync(int id)
    {
        await _clientBlacklistRepository.RemoveClientBlacklistAsync(id).ConfigureAwait(false);
    }

    public async Task<ClientBlacklistDTO> UpdateClientBlacklistAsync(ClientBlacklistDTO clientBlacklistDTO)
    {
        var clientBlacklist = _mapper.Map<ClientBlacklist>(clientBlacklistDTO);
        clientBlacklist = await _clientBlacklistRepository.UpdateClientBlacklistAsync(clientBlacklist).ConfigureAwait(false);
        clientBlacklistDTO = _mapper.Map<ClientBlacklistDTO>(clientBlacklist);
        return clientBlacklistDTO;
    }
}
