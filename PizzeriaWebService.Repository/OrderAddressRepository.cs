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

public class OrderAddressRepository : IOrderAddressRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderAddressRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderAddress>> GetOrderAddressesAsync()
    {
        return await _context.OrderAddresses.Include(oa=>oa.City).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderAddress>> GetOrderAddressesByCityIdAsync(int cityId)
    {
        var orderAddress = await _context.OrderAddresses.Include(oa=>oa.City).Where(x=>x.CityId == cityId).ToListAsync().ConfigureAwait(false);
        if (!orderAddress.Any())
            throw new RequestedItemDoesNotExistException($"Order address with provided city Id: {cityId} does not exist!");
        return orderAddress;
    }

    public async Task<OrderAddress> GetOrderAddressByOrderIdAsync(int orderPlacedId)
    {
        var orderAddress = await _context.OrderAddresses.Include(oa=>oa.City).FirstOrDefaultAsync(x=>x.OrderPlacedId == orderPlacedId).ConfigureAwait(false);
        return orderAddress ?? throw new RequestedItemDoesNotExistException($"Order address with provided order Id: {orderPlacedId} does not exist!");
    }

    public async Task RemoveOrderAddressAsync(int orderPlacedId)
    {
        var orderAddressToRemove = await _context.OrderAddresses.FindAsync(orderPlacedId).ConfigureAwait(false);
        if (orderAddressToRemove is null)
            return;
        _context.OrderAddresses.Remove(orderAddressToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderAddress> AddOrderAddressAsync(OrderAddress orderAddress)
    {
        orderAddress.City = null;
        if (await _context.OrderAddresses.FindAsync(orderAddress.OrderPlacedId).ConfigureAwait(false) is not null)
            throw new ProvidedItemAlreadyExistsException($"Order address with provided order Id: {orderAddress.OrderPlacedId} already exists!");
        var resultOrderAddress = await _context.AddAsync(orderAddress).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetOrderAddressByOrderIdAsync(resultOrderAddress.Entity.OrderPlacedId).ConfigureAwait(false);
    }

    public async Task<OrderAddress> UpdateOrderAddressAsync(OrderAddress orderAddress)
    {
        orderAddress.City = null;
        var orderAddressToUpdate = await _context.OrderAddresses.FindAsync(orderAddress.OrderPlacedId).ConfigureAwait(false);
        if (orderAddressToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Order Address with provided order Id: {orderAddress.OrderPlacedId} does not exist!");
        orderAddressToUpdate.StreetName = orderAddress.StreetName;
        orderAddressToUpdate.Apartment = orderAddress.Apartment;
        orderAddressToUpdate.CityId = orderAddress.CityId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetOrderAddressByOrderIdAsync(orderAddressToUpdate.OrderPlacedId).ConfigureAwait(false);
    }
}
