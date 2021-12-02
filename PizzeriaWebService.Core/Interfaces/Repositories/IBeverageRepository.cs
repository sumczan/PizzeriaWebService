using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IBeverageRepository
{
    Task<Beverage> AddBeverage(Beverage beverage);
    Task<IEnumerable<Beverage>> GetAlcoholicBeverages();
    Task<Beverage> GetBeverageById(int id);
    Task<Beverage> GetBeverageByName(string name);
    Task<IEnumerable<Beverage>> GetBeverages();
    Task<IEnumerable<Beverage>> GetNonAlcoholicBeverages();
    Task RemoveBeverage(int id);
    Task<Beverage> UpdateBeverage(Beverage beverage);
}
