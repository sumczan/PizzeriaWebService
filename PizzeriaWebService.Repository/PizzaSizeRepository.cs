using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Repository;

public class PizzaSizeRepository : IPizzaSizeRepository
{
    private readonly PizzeriaDbContext _context;

    public PizzaSizeRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PizzaSize>> GetPizzaSizesAsync()
    {
        return await _context.PizzaSizes.ToListAsync().ConfigureAwait(false);
    }

    public async Task<PizzaSize> GetPizzaSizeByIdAsync(int id)
    {
        var resultPizzaSize = await _context.PizzaSizes.FindAsync(id).ConfigureAwait(false);
        return resultPizzaSize ?? throw new RequestedItemDoesNotExistException($"Pizza size with provided Id: {id} does not exist!");
    }

    public async Task<PizzaSize> GetPizzaSizeByNameAsync(string sizeName)
    {
        var resultPizzaSize = await _context.PizzaSizes.FirstOrDefaultAsync(x=>x.SizeName==sizeName).ConfigureAwait(false);
        return resultPizzaSize ?? throw new RequestedItemDoesNotExistException($"Pizza size with provided size name: {sizeName} does not exist!");
    }

    public async Task RemovePizzaSizeAsync(int id)
    {
        var pizzaSizeToRemove = await _context.PizzaSizes.FindAsync(id).ConfigureAwait(false);
        if (pizzaSizeToRemove is null)
            return;
        _context.PizzaSizes.Remove(pizzaSizeToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<PizzaSize> AddPizzaSizeAsync(PizzaSize pizzaSize)
    {
        pizzaSize.Id = 0;
        var pizzaSizeFromDb = await _context.PizzaSizes.FirstOrDefaultAsync(x=>x.SizeName==pizzaSize.SizeName).ConfigureAwait(false);
        if (pizzaSizeFromDb is not null)
            throw new ProvidedItemAlreadyExistsException($"Pizza size with provided size name: {pizzaSize.SizeName} already exists!");
        var resultPizzaSize = await _context.PizzaSizes.AddAsync(pizzaSize).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultPizzaSize.Entity;
    }

    public async Task<PizzaSize> UpdatePizzaSizeAsync(PizzaSize pizzaSize)
    {
        var pizzaSizeToUpdate = await _context.PizzaSizes.FindAsync(pizzaSize.Id).ConfigureAwait(false);
        if (pizzaSizeToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Pizza size with provided Id: {pizzaSize.Id} does not exist!");
        if (!Equals(pizzaSizeToUpdate.SizeName, pizzaSize.SizeName))
            if (await _context.PizzaSizes.FirstOrDefaultAsync(x => x.SizeName == pizzaSize.SizeName).ConfigureAwait(false) is not null)
                throw new ProvidedItemAlreadyExistsException($"Pizza size with provided size name: {pizzaSize.SizeName} already exists!");
        pizzaSizeToUpdate.PriceMultiplier = pizzaSize.PriceMultiplier;
        pizzaSizeToUpdate.SizeName = pizzaSize.SizeName;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return pizzaSizeToUpdate;
    }
}
