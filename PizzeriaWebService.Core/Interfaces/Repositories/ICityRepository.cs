using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface ICityRepository
{
    Task<City> AddCityAsync(City city);
    Task<IEnumerable<City>> GetCitiesAsync();
    Task<City> GetCityByIdAsync(int id);
    Task<City> GetCityByNameAsync(string cityName);
    Task RemoveCityAsync(int id);
    Task<City> UpdateCityAsync(City city);
}
