using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IPizzaSizeRepository
{
    Task<PizzaSize> AddPizzaSizeAsync(PizzaSize pizzaSize);
    Task<PizzaSize> GetPizzaSizeByIdAsync(int id);
    Task<PizzaSize> GetPizzaSizeByNameAsync(string sizeName);
    Task<IEnumerable<PizzaSize>> GetPizzaSizesAsync();
    Task RemovePizzaSizeAsync(int id);
    Task<PizzaSize> UpdatePizzaSizeAsync(PizzaSize pizzaSize);
}
