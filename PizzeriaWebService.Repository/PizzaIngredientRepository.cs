using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class PizzaIngredientRepository : IPizzaIngredientRepository
{
    private readonly PizzeriaDbContext _context;

    public PizzaIngredientRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PizzaIngredient>> GetPizzaIngredientsAsync()
    {
        return await _context.PizzaIngredients.ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<PizzaIngredient>> GetPizzaIngredientsByPizzaIdAsync(int pizzaId)
    {
        var resultPizzaIngredients = await _context.PizzaIngredients.Where(x=>x.PizzaId==pizzaId).ToListAsync().ConfigureAwait(false);
        if (!resultPizzaIngredients.Any())
            throw new RequestedItemDoesNotExistException($"Pizza ingredients with provided pizza Id: {pizzaId} do not exist!");
        return resultPizzaIngredients;
    }

    public async Task<IEnumerable<PizzaIngredient>> GetPizzaIngredientsByIngredientIdAsync(int ingredientId)
    {
        var resultPizzaIngredients = await _context.PizzaIngredients.Where(x=>x.IngredientId==ingredientId).ToListAsync().ConfigureAwait(false);
        if (!resultPizzaIngredients.Any())
            throw new RequestedItemDoesNotExistException($"Pizza ingredients with provided ingredient Id: {ingredientId} do not exist!");
        return resultPizzaIngredients;
    }

    public async Task<PizzaIngredient> GetPizzaIngredientByIdAsync(int id)
    {
        var resultPizzaIngredient = await _context.PizzaIngredients.FindAsync(id).ConfigureAwait(false);
        return resultPizzaIngredient ?? throw new RequestedItemDoesNotExistException($"Pizza ingredients with provided Id: {id} does not exist!");
    }

    public async Task RemovePizzaIngredientAsync(int id)
    {
        var pizzaIngredientToRemove = await _context.PizzaIngredients.FindAsync(id).ConfigureAwait(false);
        if (pizzaIngredientToRemove is null)
            return;
        _context.PizzaIngredients.Remove(pizzaIngredientToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<PizzaIngredient> AddPizzaIngredientAsync(PizzaIngredient pizzaIngredient)
    {
        pizzaIngredient.Id = 0;
        var resultPizzaIngredient = await _context.PizzaIngredients.AddAsync(pizzaIngredient).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultPizzaIngredient.Entity;
    }

    public async Task<PizzaIngredient> UpdatePizzaIngredientAsync(PizzaIngredient pizzaIngredient)
    {
        var pizzaIngredientToUpdate = await _context.PizzaIngredients.FindAsync(pizzaIngredient.Id).ConfigureAwait(false);
        if(pizzaIngredientToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Pizza ingredient with provided Id: {pizzaIngredient.Id} does not exist!");
        if (pizzaIngredient.PizzaId != pizzaIngredientToUpdate.PizzaId)
            throw new ProvidedObjectNotValidException($"Provided pizza ingredient pizza Id: {pizzaIngredient.PizzaId} does not match Id: {pizzaIngredientToUpdate.PizzaId}!");
        pizzaIngredientToUpdate.IngredientId = pizzaIngredient.IngredientId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return pizzaIngredientToUpdate;
    }
}
