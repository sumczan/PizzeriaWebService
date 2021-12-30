using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IPizzaService
{
    Task<IEnumerable<PizzaDTO>> GetPizzasAsync();
    Task<PizzaDTO> GetPizzaByIdAsync(int id);
    Task<PizzaDTO> GetPizzaByNameAsync(string pizzaName);
    Task RemovePizzaAsync(int id);
    Task<PizzaDTO> AddPizzaAsync(PizzaDTO pizzaDTO);
    Task<PizzaDTO> UpdatePizzaAsync(PizzaDTO pizzaDTO);
}
