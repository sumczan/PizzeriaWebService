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

public class BeverageRepository : IBeverageRepository
{
    private readonly PizzeriaDbContext _context;

    public BeverageRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Beverage>> GetBeveragesAsync()
    {
        return await _context.Beverages.ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Beverage>> GetAlcoholicBeveragesAsync()
    {
        return await _context.Beverages.Where(x=>x.IsAlcoholic).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Beverage>> GetNonAlcoholicBeveragesAsync()
    {
        return await _context.Beverages.Where(x=>!x.IsAlcoholic).ToListAsync().ConfigureAwait(false);
    }

    public async Task<Beverage> GetBeverageByIdAsync(int id)
    {
        var beverage = await _context.Beverages.FindAsync(id).ConfigureAwait(false);
        return beverage ?? throw new RequestedItemDoesNotExistException($"Beverage with provided Id: {id} does not exist!");
    }

    public async Task<Beverage> GetBeverageByNameAsync(string beverageName)
    {
        var beverage = await _context.Beverages.FirstOrDefaultAsync(x=>x.BeverageName==beverageName).ConfigureAwait(false);
        return beverage ?? throw new RequestedItemDoesNotExistException($"Beverage with provided beverage name: {beverageName} does not exist!"); ;
    }

    public async Task RemoveBeverageAsync(int id)
    {
        var beverage = await _context.Beverages.FindAsync(id).ConfigureAwait(false);
        if (beverage is null)
            return;
        _context.Beverages.Remove(beverage);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<Beverage> AddBeverageAsync(Beverage beverage)
    {
        beverage.Id = 0;
        var beverageFromDb = await _context.Beverages
            .FirstOrDefaultAsync(x=>x.BeverageName==beverage.BeverageName)
            .ConfigureAwait(false);
        if (beverageFromDb is not null)
            throw new ProvidedItemAlreadyExistsException($"Beverage with provided name: {beverage.BeverageName} already exists!");
        var resultBeverage = await _context.Beverages.AddAsync(beverage).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultBeverage.Entity;
    }

    public async Task<Beverage> UpdateBeverageAsync(Beverage beverage)
    {
        var beverageToUpdate = await _context.Beverages.FindAsync(beverage.Id).ConfigureAwait(false);
        if (beverageToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Beverage with provided Id: {beverage.Id} does not exist!");
        
        if (!Equals(beverage.BeverageName, beverageToUpdate.BeverageName))
            if (await _context.Beverages.FirstOrDefaultAsync(x => x.BeverageName == beverage.BeverageName).ConfigureAwait(false) is not null)
                throw new ProvidedItemAlreadyExistsException($"Beverage with provided name: {beverage.BeverageName} already exists!");

        beverageToUpdate.BeverageName = beverage.BeverageName;
        beverageToUpdate.BeveragePrice = beverage.BeveragePrice;
        beverageToUpdate.IsAlcoholic = beverage.IsAlcoholic;

        await _context.SaveChangesAsync().ConfigureAwait(false);

        return beverageToUpdate;
    }
}
