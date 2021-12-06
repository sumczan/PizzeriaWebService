using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzeriaWebService.Repository;

public class IngredientTypeRepository : IIngredientTypeRepository
{
    private readonly PizzeriaDbContext _context;

    public IngredientTypeRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IngredientType>> GetIngredientTypesAsync()
    {
        return await _context.IngredientTypes.ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<IngredientType>> GetIngredientTypesMeatAsync()
    {
        return await _context.IngredientTypes.Where(x=>x.IsMeat).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<IngredientType>> GetIngredientTypesVegetableAsync()
    {
        return await _context.IngredientTypes.Where(x=>x.IsVegetable).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<IngredientType>> GetIngredientTypesVeganAsync()
    {
        return await _context.IngredientTypes.Where(x=>x.IsVegan).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<IngredientType>> GetIngredientTypesDairyAsync()
    {
        return await _context.IngredientTypes.Where(x=>x.IsDairy).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<IngredientType>> GetIngredientTypesGlutenFreeAsync()
    {
        return await _context.IngredientTypes.Where(x=>x.IsGlutenFree).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IngredientType> GetIngredientTypeByIdAsync(int id)
    {
        var ingredientType = await _context.IngredientTypes.FindAsync(id).ConfigureAwait(false);
        return ingredientType ?? throw new RequestedItemDoesNotExistException($"Ingredient type with provided Id: {id} does not exist!");
    }

    public async Task<IngredientType> GetIngredientTypeByNameAsync(string ingredientTypeName)
    {
        var ingredientType = await _context.IngredientTypes.FirstOrDefaultAsync(x=>x.IngredientTypeName==ingredientTypeName).ConfigureAwait(false);
        return ingredientType ?? throw new RequestedItemDoesNotExistException($"Ingredient type with provided name: {ingredientTypeName} does not exist!");
    }

    public async Task RemoveIngredientTypeAsync(int id)
    {
        var ingredientTypeToRemove = await _context.IngredientTypes.FindAsync(id);
        if (ingredientTypeToRemove is null)
            return;
        _context.IngredientTypes.Remove(ingredientTypeToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IngredientType> AddIngredientTypeAsync(IngredientType ingredientType)
    {
        ingredientType.Id = 0;
        if (ingredientType.IsMeat && (ingredientType.IsVegetable || ingredientType.IsDairy || ingredientType.IsVegan))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for meat: {JsonSerializer.Serialize(ingredientType)}");
        if(ingredientType.IsVegan && !(ingredientType.IsMeat || ingredientType.IsDairy))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for vegan: {JsonSerializer.Serialize(ingredientType)}");
        if(ingredientType.IsVegetable && ingredientType.IsVegan && !(ingredientType.IsMeat || ingredientType.IsDairy))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for vegetable: {JsonSerializer.Serialize(ingredientType)}");
        if(ingredientType.IsDairy && !ingredientType.IsVegan && (ingredientType.IsMeat || ingredientType.IsVegetable))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for dairy: {JsonSerializer.Serialize(ingredientType)}");

        if (await _context.IngredientTypes.FirstOrDefaultAsync(x => x.IngredientTypeName == ingredientType.IngredientTypeName).ConfigureAwait(false) is not null)
            throw new ProvidedItemAlreadyExistsException($"Ingredient type with provided name: {ingredientType.IngredientTypeName} already exists!");

        var resultIngredientType = await _context.IngredientTypes.AddAsync(ingredientType).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultIngredientType.Entity;
    }

    public async Task<IngredientType> UpdateIngredientTypeAsync(IngredientType ingredientType)
    {
        var ingredientTypeToUpdate = await _context.IngredientTypes.FindAsync(ingredientType.Id).ConfigureAwait(false);
        if (ingredientTypeToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Ingredient type with provided Id: {ingredientType.Id} does not exist!");

        if (ingredientType.IsMeat && (ingredientType.IsVegetable || ingredientType.IsDairy || ingredientType.IsVegan))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for meat: {JsonSerializer.Serialize(ingredientType)}");
        if (ingredientType.IsVegan && !(ingredientType.IsMeat || ingredientType.IsDairy))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for vegan: {JsonSerializer.Serialize(ingredientType)}");
        if (ingredientType.IsVegetable && ingredientType.IsVegan && !(ingredientType.IsMeat || ingredientType.IsDairy))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for vegetable: {JsonSerializer.Serialize(ingredientType)}");
        if (ingredientType.IsDairy && !ingredientType.IsVegan && (ingredientType.IsMeat || ingredientType.IsVegetable))
            throw new ProvidedObjectNotValidException($"Provided ingredient type object is not valid for dairy: {JsonSerializer.Serialize(ingredientType)}");

        if (!Equals(ingredientType.IngredientTypeName, ingredientTypeToUpdate.IngredientTypeName))
            if (await _context.IngredientTypes.FirstOrDefaultAsync(x => x.IngredientTypeName == ingredientType.IngredientTypeName).ConfigureAwait(false) is not null)
                throw new ProvidedItemAlreadyExistsException($"Ingredient type with provided name: {ingredientType.IngredientTypeName} already exists!");

        ingredientTypeToUpdate.IngredientTypeName = ingredientType.IngredientTypeName;
        ingredientTypeToUpdate.IsGlutenFree = ingredientType.IsGlutenFree;
        ingredientTypeToUpdate.IsVegetable = ingredientType.IsVegetable;
        ingredientTypeToUpdate.IsVegan = ingredientType.IsVegan;
        ingredientTypeToUpdate.IsDairy = ingredientType.IsDairy;
        ingredientTypeToUpdate.IsMeat = ingredientType.IsMeat;

        await _context.SaveChangesAsync().ConfigureAwait(false);
        return ingredientTypeToUpdate;
    }
}
