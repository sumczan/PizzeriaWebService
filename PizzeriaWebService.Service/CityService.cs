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

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CityService(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CityDTO>> GetCitiesAsync()
    {
        var cities = await _cityRepository.GetCitiesAsync().ConfigureAwait(false);
        var cityDTOs = _mapper.Map<IEnumerable<CityDTO>>(cities);
        return cityDTOs;
    }

    public async Task<CityDTO> GetCityByIdAsync(int id)
    {
        var city = await _cityRepository.GetCityByIdAsync(id).ConfigureAwait(false);
        var cityDTO = _mapper.Map<CityDTO>(city);
        return cityDTO;
    }

    public async Task<CityDTO> GetCityByNameAsync(string cityName)
    {
        var city = await _cityRepository.GetCityByNameAsync(cityName).ConfigureAwait(false);
        var cityDTO = _mapper.Map<CityDTO>(city);
        return cityDTO;
    }

    public async Task<CityDTO> AddCityAsync(CityDTO cityDTO)
    {
        var city = _mapper.Map<City>(cityDTO);
        city = await _cityRepository.AddCityAsync(city).ConfigureAwait(false);
        cityDTO = _mapper.Map<CityDTO>(city);
        return cityDTO;
    }

    public async Task RemoveCityAsync(int id)
    {
        await _cityRepository.RemoveCityAsync(id).ConfigureAwait(false);
    }

    public async Task<CityDTO> UpdateCityAsync(CityDTO cityDTO)
    {
        var city = _mapper.Map<City>(cityDTO);
        city = await _cityRepository.UpdateCityAsync(city).ConfigureAwait(false);
        cityDTO = _mapper.Map<CityDTO>(city);
        return cityDTO;
    }
}
