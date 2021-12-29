using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IPizzaRepository
{
    Task<Pizza> AddPizzaAsync(Pizza pizza);
    Task<Pizza> GetPizzaByIdAsync(int id);
    Task<Pizza> GetPizzaByNameAsync(string pizzaName);
    Task<IEnumerable<Pizza>> GetPizzasAsync();
    Task RemovePizzaAsync(int id);
    Task<Pizza> UpdatePizzaAsync(Pizza pizza);
}
