using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Service;

public class ClientBlacklistService : IClientBlacklistService
{
    private readonly IClientBlacklistRepository _clientBlacklistRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public ClientBlacklistService(IClientBlacklistRepository clientBlacklistRepository, ICityRepository cityRepository, IMapper mapper)
    {
        _clientBlacklistRepository = clientBlacklistRepository;
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientBlacklistDTO>> GetClientBlacklistsAsync()
    {
        var clientBlacklists = await _clientBlacklistRepository.GetClientBlacklistAsync().ConfigureAwait(false);
        var clientBlacklistDTOs = _mapper.Map<IEnumerable<ClientBlacklistDTO>>(clientBlacklists);
        return clientBlacklistDTOs;
    }
}
