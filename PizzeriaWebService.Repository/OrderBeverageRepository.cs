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

public class OrderBeverageRepository : IOrderBeverageRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderBeverageRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderBeverage>> GetOrderBeveragesAsync()
    {
        return await _context.OrderBeverages.ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderBeverage>> GetOrderBeveragesByOrderIdAsync(int orderId)
    {
        var orderBeverage = await _context.OrderBeverages.Where(x=>x.OrderPlacedId==orderId).ToListAsync().ConfigureAwait(false);
        if (!orderBeverage.Any())
            throw new RequestedItemDoesNotExistException($"Order Beverage with provided order Id: {orderId} does not exist!");
        return orderBeverage;
    }

    public async Task<OrderBeverage> GetOrderBeverageByIdAsync(int id)
    {
        var orderBeverage = await _context.OrderBeverages.FindAsync(id).ConfigureAwait(false);
        if (orderBeverage is null)
            throw new RequestedItemDoesNotExistException($"Order Beverage with provided Id: {id} does not exist!");
        return orderBeverage;
    }

    public async Task RemoveOrderBeverageAsync(int id)
    {
        var orderBeverageToRemove = await _context.OrderBeverages.FindAsync(id).ConfigureAwait(false);
        if (orderBeverageToRemove is null)
            return;
        _context.OrderBeverages.Remove(orderBeverageToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderBeverage> AddOrderBeverageAsync(OrderBeverage orderBeverage)
    {
        orderBeverage.Id = 0;
        var resultOrderBeverage = await _context.OrderBeverages.AddAsync(orderBeverage).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultOrderBeverage.Entity;
    }

    public async Task<OrderBeverage> UpdateOrderBeverageAsync(OrderBeverage orderBeverage)
    {
        var orderBeverageToUpdate = await _context.OrderBeverages.FindAsync(orderBeverage.Id).ConfigureAwait(false);
        if (orderBeverageToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Order Beverage with provided Id: {orderBeverage.Id} does not exist!");
        if (orderBeverage.OrderPlacedId != orderBeverageToUpdate.OrderPlacedId)
            throw new ProvidedObjectNotValidException(
                $"Provided Order Beverage has different order Id: {orderBeverage.OrderPlacedId} than the saved one: {orderBeverageToUpdate.OrderPlacedId}");
        orderBeverageToUpdate.OrderBeveragePrice = orderBeverage.OrderBeveragePrice;
        orderBeverageToUpdate.BeverageId = orderBeverage.BeverageId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return orderBeverageToUpdate;
    }
}
