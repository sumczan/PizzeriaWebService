using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Repository;

public class CityRepository : ICityRepository
{
    private readonly PizzeriaDbContext _context;

    public CityRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetCities()
    {
        return await _context.Cities.ToListAsync().ConfigureAwait(false);
    }

    public async Task<City> GetCityById(int id)
    {
        var city = await _context.Cities.FindAsync(id).ConfigureAwait(false);
        return city ?? throw new RequestedItemDoesNotExistException($"City with provided Id: {id} does not exist!");
    }

    public async Task<City> GetCityByName(string cityName)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(x=>x.CityName == cityName).ConfigureAwait(false);
        return city ?? throw new RequestedItemDoesNotExistException($"City with provided name: {cityName} does not exist!");
    }

    public async Task<City> AddCity(City city)
    {
        city.Id = 0;
        var cityFromDb = await _context.Cities.FirstOrDefaultAsync(x=>x.CityName==city.CityName).ConfigureAwait(false);
        if (cityFromDb is not null)
            throw new ProvidedItemAlreadyExistsException($"City with provided name: {city.CityName} already exists!");
        var resultCity = await _context.Cities.AddAsync(city).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultCity.Entity;
    }

    public async Task RemoveCity(int id)
    {
        var city = await _context.Cities.FindAsync(id).ConfigureAwait(false);
        if (city is null)
            return;
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<City> UpdateCity(City city)
    {
        var cityToUpdate = await _context.Cities.FindAsync(city.Id).ConfigureAwait(false);
        if (cityToUpdate is null)
            throw new RequestedItemDoesNotExistException($"City with provided Id: {city.Id} does not exist!");
        if (await _context.Cities.FirstOrDefaultAsync(x => x.CityName == city.CityName).ConfigureAwait(false) is not null)
            throw new ProvidedItemAlreadyExistsException($"City with provided name: {city.CityName} already exists!");
        cityToUpdate.CityName = city.CityName;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return cityToUpdate;
    }
}
