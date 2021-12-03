using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
