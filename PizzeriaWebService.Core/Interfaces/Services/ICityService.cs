using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface ICityService
{
    Task<CityDTO> AddCityAsync(CityDTO cityDTO);
    Task<IEnumerable<CityDTO>> GetCitiesAsync();
    Task<CityDTO> GetCityByIdAsync(int id);
    Task<CityDTO> GetCityByNameAsync(string cityName);
    Task RemoveCityAsync(int id);
    Task<CityDTO> UpdateCityAsync(CityDTO cityDTO);
}
