using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Service;

public class BeverageService : IBeverageService
{
    private readonly IBeverageRepository _beverageRepository;
    private readonly IMapper _mapper;

    public BeverageService(IBeverageRepository beverageRepository, IMapper mapper)
    {
        _beverageRepository = beverageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BeverageDTO>> GetBeveragesAsync()
    {
        var beverages = await _beverageRepository.GetBeveragesAsync().ConfigureAwait(false);
        var beverageDTOs = _mapper.Map<IEnumerable<BeverageDTO>>(beverages);
        return beverageDTOs;
    }

    public async Task<IEnumerable<BeverageDTO>> GetAlcoholicBeveragesAsync()
    {
        var beverages = await _beverageRepository.GetAlcoholicBeveragesAsync().ConfigureAwait(false);
        var beveragesDTOs = _mapper.Map<IEnumerable<BeverageDTO>>(beverages);
        return beveragesDTOs;
    }

    public async Task<IEnumerable<BeverageDTO>> GetNonAlcoholicBeveragesAsync()
    {
        var beverages = await _beverageRepository.GetNonAlcoholicBeveragesAsync().ConfigureAwait(false);
        var beveragesDTOs = _mapper.Map<IEnumerable<BeverageDTO>>(beverages);
        return beveragesDTOs;
    }

    public async Task<BeverageDTO> GetBeverageByIdAsync(int id)
    {
        var beverage = await _beverageRepository.GetBeverageByIdAsync(id).ConfigureAwait(false);
        var beverageDTO = _mapper.Map<BeverageDTO>(beverage);
        return beverageDTO;
    }

    public async Task<BeverageDTO> GetBeverageByNameAsync(string beverageName)
    {
        var beverage = await _beverageRepository.GetBeverageByNameAsync(beverageName).ConfigureAwait(false);
        var beverageDTO = _mapper.Map<BeverageDTO>(beverage);
        return beverageDTO;
    }

    public async Task RemoveBeverageAsync(int id)
    {
        await _beverageRepository.RemoveBeverageAsync(id).ConfigureAwait(false);
    }

    public async Task<BeverageDTO> AddBeverageAsync(BeverageDTO beverageDTO)
    {
        var beverage = _mapper.Map<Beverage>(beverageDTO);
        beverage = await _beverageRepository.AddBeverageAsync(beverage).ConfigureAwait(false);
        beverageDTO = _mapper.Map<BeverageDTO>(beverage);
        return beverageDTO;
    }

    public async Task<BeverageDTO> UpdateBeverageAsync(BeverageDTO beverageDTO)
    {
        var beverage = _mapper.Map<Beverage>(beverageDTO);
        beverage = await _beverageRepository.UpdateBeverageAsync(beverage).ConfigureAwait(false);
        beverageDTO = _mapper.Map<BeverageDTO>(beverage);
        return beverageDTO;
    }
}
