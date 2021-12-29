using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class IngredientRepository : IIngredientRepository
{
    private readonly PizzeriaDbContext _context;

    public IngredientRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        return await _context.Ingredients.Include(it=>it.IngredientType).ToListAsync().ConfigureAwait(false);
    }

    public async Task<Ingredient> GetIngredientByIdAsync(int id)
    {
        var ingredient = await _context.Ingredients.Include(it=>it.IngredientType).FirstOrDefaultAsync(x=>x.Id==id).ConfigureAwait(false);
        return ingredient ?? throw new RequestedItemDoesNotExistException($"Ingredient with provided Id: {id} does not exist!");
    }

    public async Task<Ingredient> GetIngredientByNameAsync(string ingredientName)
    {
        var ingredient = await _context.Ingredients.Include(it=>it.IngredientType).FirstOrDefaultAsync(x=>x.IngredientName==ingredientName).ConfigureAwait(false);
        return ingredient ?? throw new RequestedItemDoesNotExistException($"Ingredient with provided name: {ingredientName} does not exist!");
    }

    public async Task RemoveIngredientAsync(int id)
    {
        var ingredientToRemove = await _context.Ingredients.FindAsync(id);
        if (ingredientToRemove is null)
            return;
        _context.Ingredients.Remove(ingredientToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
    {
        ingredient.Id = 0;
        ingredient.IngredientType = null;
        var ingredientFromDb = await _context.Ingredients.FirstOrDefaultAsync(x=>x.IngredientName==ingredient.IngredientName).ConfigureAwait(false);
        if (ingredientFromDb is not null)
            throw new ProvidedItemAlreadyExistsException($"Ingredient with provided name: {ingredient.IngredientName} already exists!");
        var resultIngredient = await _context.Ingredients.AddAsync(ingredient).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetIngredientByIdAsync(resultIngredient.Entity.Id).ConfigureAwait(false);
    }

    public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
    {
        ingredient.IngredientType = null;
        var ingredientToUpdate = await _context.Ingredients.FindAsync(ingredient.Id).ConfigureAwait(false);
        if (ingredientToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Ingredient with provided Id: {ingredient.Id} does not exist!");
        if (!Equals(ingredient.IngredientName, ingredientToUpdate.IngredientName))
            if (await _context.Ingredients.FirstOrDefaultAsync(x => x.IngredientName == ingredient.IngredientName).ConfigureAwait(false) is not null)
                throw new ProvidedItemAlreadyExistsException($"Ingredient with provided name: {ingredient.IngredientName} already exists!");
        ingredientToUpdate.IngredientName = ingredient.IngredientName;
        ingredientToUpdate.IngredientPrice = ingredient.IngredientPrice;
        ingredientToUpdate.IngredientTypeId = ingredient.IngredientTypeId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetIngredientByIdAsync(ingredientToUpdate.Id).ConfigureAwait(false);
    }
}
