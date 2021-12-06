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

public class OrderTypeRepository : IOrderTypeRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderTypeRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderType>> GetOrderTypesAsync()
    {
        return await _context.OrderTypes.ToListAsync().ConfigureAwait(false);
    }

    public async Task<OrderType> GetOrderTypeByIdAsync(int id)
    {
        var resultOrderType = await _context.OrderTypes.FindAsync(id).ConfigureAwait(false);
        return resultOrderType ?? throw new RequestedItemDoesNotExistException($"Order type with provided Id: {id} does not exist!");
    }

    public async Task<OrderType> GetOrderTypeByNameAsync(string orderTypeName)
    {
        var resultOrderType = await _context.OrderTypes.FirstOrDefaultAsync(x=>x.OrderTypeName == orderTypeName).ConfigureAwait(false);
        return resultOrderType ?? throw new RequestedItemDoesNotExistException($"Order type with provided name: {orderTypeName} does not exist!");
    }

    public async Task RemoveOrderTypeAsync(int id)
    {
        var orderTypeToRemove = await _context.OrderTypes.FindAsync(id).ConfigureAwait(false);
        if (orderTypeToRemove is null)
            return;
        _context.OrderTypes.Remove(orderTypeToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderType> AddOrderTypeAsync(OrderType orderType)
    {
        orderType.Id = 0;
        var orderTypeFromDb = await _context.OrderTypes.FirstOrDefaultAsync(x=>x.OrderTypeName==orderType.OrderTypeName).ConfigureAwait(false);
        if (orderTypeFromDb is null)
            throw new ProvidedItemAlreadyExistsException($"Order type with provided name: {orderType.OrderTypeName} already exists!");
        var resultOrderType = await _context.OrderTypes.AddAsync(orderType).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultOrderType.Entity;
    }

    public async Task<OrderType> UpdateOrderTypeAsync(OrderType orderType)
    {
        var orderTypeToUpdate = await _context.OrderTypes.FindAsync(orderType.Id).ConfigureAwait(false);
        if (orderTypeToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Order type with provided Id: {orderType.Id} does not exist");
        if (!Equals(orderType.OrderTypeName, orderTypeToUpdate.OrderTypeName))
            if (await _context.OrderTypes.FirstOrDefaultAsync(x => x.OrderTypeName == orderType.OrderTypeName) is not null)
                throw new ProvidedItemAlreadyExistsException($"Order type with provided name: {orderType.OrderTypeName} already exists!");
        orderTypeToUpdate.OrderTypeName = orderType.OrderTypeName;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return orderTypeToUpdate;
    }
}
