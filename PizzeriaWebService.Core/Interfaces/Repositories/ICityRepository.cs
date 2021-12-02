using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface ICityRepository
{
    Task<City> AddCity(City city);
    Task<IEnumerable<City>> GetCities();
    Task<City> GetCityById(int id);
    Task<City> GetCityByName(string cityName);
    Task RemoveCity(int id);
    Task<City> UpdateCity(City city);
}
