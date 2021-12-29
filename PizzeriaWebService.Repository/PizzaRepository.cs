using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzeriaDbContext _context;

    public PizzaRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pizza>> GetPizzasAsync()
    {
        return await _context.Pizzas.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Pizza> GetPizzaByIdAsync(int id)
    {
        var resultPizza = await _context.Pizzas.FindAsync(id).ConfigureAwait(false);
        return resultPizza ?? throw new RequestedItemDoesNotExistException($"Pizza with provided Id: {id} does not exist!");
    }

    public async Task<Pizza> GetPizzaByNameAsync(string pizzaName)
    {
        var resultPizza = await _context.Pizzas.FirstOrDefaultAsync(x=>x.PizzaName==pizzaName).ConfigureAwait(false);
        return resultPizza ?? throw new RequestedItemDoesNotExistException($"Pizza with provided name: {pizzaName} does not exist!");
    }

    public async Task RemovePizzaAsync(int id)
    {
        var pizzaToRemove = await _context.Pizzas.FindAsync(id).ConfigureAwait(false);
        if (pizzaToRemove is null)
            return;
        _context.Pizzas.Remove(pizzaToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<Pizza> AddPizzaAsync(Pizza pizza)
    {
        pizza.Id = 0;
        var pizzaFromDb = await _context.Pizzas.FirstOrDefaultAsync(x=>x.PizzaName==pizza.PizzaName).ConfigureAwait(false);
        if(pizzaFromDb is not null)
            throw new ProvidedItemAlreadyExistsException($"Pizza with provided name: {pizza.PizzaName} already exists!");
        var resultPizza = await _context.Pizzas.AddAsync(pizza).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultPizza.Entity;
    }

    public async Task<Pizza> UpdatePizzaAsync(Pizza pizza)
    {
        var pizzaToUpdate = await _context.Pizzas.FindAsync(pizza.Id).ConfigureAwait(false);
        if (pizzaToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Pizza with provided Id: {pizza.Id} does not exist!");
        if (!Equals(pizza.PizzaName, pizzaToUpdate.PizzaName))
            if (await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaName == pizza.PizzaName) is not null)
                throw new ProvidedItemAlreadyExistsException($"Pizza with provided name: {pizza.PizzaName} already exists!");
        pizzaToUpdate.PizzaPrice = pizza.PizzaPrice;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return pizzaToUpdate;
    }
}
