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

public class ClientBlacklistRepository : IClientBlacklistRepository
{
    private readonly PizzeriaDbContext _context;

    public ClientBlacklistRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientBlacklist>> GetClientBlacklistAsync()
    {
        return await _context.ClientBlacklists.Include(c => c.City).ToListAsync().ConfigureAwait(false);
    }

    public async Task<ClientBlacklist> GetClientBlacklistByIdAsync(int id)
    {
        var clientBlacklist = await _context.ClientBlacklists.Include(c=>c.City).FirstOrDefaultAsync(x=>x.Id == id).ConfigureAwait(false);
        return clientBlacklist ?? throw new RequestedItemDoesNotExistException($"Client blacklist with provided {id} does not exist!");
    }

    public async Task<ClientBlacklist> AddClientBlacklistAsync(ClientBlacklist clientBlacklist)
    {
        clientBlacklist.Id = 0;
        clientBlacklist.City = null;
        if (clientBlacklist.PhoneNumber is null ||
            !(!String.IsNullOrWhiteSpace(clientBlacklist.StreetName) && !String.IsNullOrWhiteSpace(clientBlacklist.Apartment) && clientBlacklist.CityId is not null))
            throw new ProvidedObjectNotValidException($"To add client blacklist either phone number is required or full address information");

        if (String.IsNullOrWhiteSpace(clientBlacklist.Details))
            throw new ProvidedObjectNotValidException($"To add client blacklist you should provide details about incident");

        var resultClientBlacklist = await _context.ClientBlacklists.AddAsync(clientBlacklist).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return await GetClientBlacklistByIdAsync(resultClientBlacklist.Entity.Id).ConfigureAwait(false);
    }

    public async Task RemoveClientBlacklistAsync(int id)
    {
        var clientBlacklistFromDb = await _context.ClientBlacklists.FindAsync(id);
        if (clientBlacklistFromDb is null)
            return;
        _context.ClientBlacklists.Remove(clientBlacklistFromDb);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<ClientBlacklist> UpdateClientBlacklistAsync(ClientBlacklist clientBlacklist)
    {
        clientBlacklist.City = null;
        var clientBlacklistToUpdate = await _context.ClientBlacklists.FindAsync(clientBlacklist.Id).ConfigureAwait(false);
        if (clientBlacklistToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Client blacklist with provided {clientBlacklist.Id} does not exist!");

        if (clientBlacklist.PhoneNumber is null ||
            !(!String.IsNullOrWhiteSpace(clientBlacklist.StreetName) && !String.IsNullOrWhiteSpace(clientBlacklist.Apartment) && clientBlacklist.CityId is not null))
            throw new ProvidedObjectNotValidException($"To add client blacklist either phone number is required or full address information");

        if (String.IsNullOrWhiteSpace(clientBlacklist.Details))
            throw new ProvidedObjectNotValidException($"To add client blacklist you should provide details about incident");

        clientBlacklistToUpdate.StreetName = clientBlacklist.StreetName;
        clientBlacklistToUpdate.Apartment = clientBlacklist.Apartment;
        clientBlacklistToUpdate.CityId = clientBlacklist.CityId;
        clientBlacklistToUpdate.PhoneNumber = clientBlacklist.PhoneNumber;
        clientBlacklistToUpdate.Details = clientBlacklist.Details;

        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetClientBlacklistByIdAsync(clientBlacklistToUpdate.Id).ConfigureAwait(false);
    }
}
