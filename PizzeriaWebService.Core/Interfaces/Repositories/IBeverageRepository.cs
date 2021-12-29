using PizzeriaWebService.Core.EfModels;

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
