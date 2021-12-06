using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
