using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IBeverageRepository
{
    Task<Beverage> AddBeverageAsync(Beverage beverage);
    Task<IEnumerable<Beverage>> GetAlcoholicBeveragesAsync();
    Task<Beverage> GetBeverageByIdAsync(int id);
    Task<Beverage> GetBeverageByNameAsync(string name);
    Task<IEnumerable<Beverage>> GetBeveragesAsync();
    Task<IEnumerable<Beverage>> GetNonAlcoholicBeveragesAsync();
    Task RemoveBeverageAsync(int id);
    Task<Beverage> UpdateBeverageAsync(Beverage beverage);
}
