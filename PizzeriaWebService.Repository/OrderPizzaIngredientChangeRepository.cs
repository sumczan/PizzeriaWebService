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

public class OrderPizzaIngredientChangeRepository : IOrderPizzaIngredientChangeRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderPizzaIngredientChangeRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderPizzaIngredientChange>> GetOrderPizzaIngredientChangesAsync()
    {
        return await _context.OrderPizzaIngredientChanges.ToListAsync().ConfigureAwait(false);
    } 

    public async Task<IEnumerable<OrderPizzaIngredientChange>> GetOrderPizzaIngredientChangesByOrderPizzaIdAsync(int orderPizzaId)
    {
        var pizzaIngredientChanges = await _context.OrderPizzaIngredientChanges.Where(x => x.OrderPizzaId == orderPizzaId).ToListAsync().ConfigureAwait(false);
        if (!pizzaIngredientChanges.Any())
            throw new RequestedItemDoesNotExistException($"Pizza ingredient changes with provided pizza order Id: {orderPizzaId} does not exist!");
        return pizzaIngredientChanges;
    }

    public async Task<OrderPizzaIngredientChange> GetOrderPizzaIngredientChangeByIdAsync(int id)
    {
        var pizzaIngredientChange = await _context.OrderPizzaIngredientChanges.FindAsync(id).ConfigureAwait(false);
        return pizzaIngredientChange ?? throw new RequestedItemDoesNotExistException($"Pizza ingredient change with provided Id: {id} does not exist!");
    }

    public async Task RemoveOrderPizzaIngredientChangeAsync(int id)
    {
        var pizzaIngredientChangeToRemove = await _context.OrderPizzaIngredientChanges.FindAsync(id).ConfigureAwait(false);
        if (pizzaIngredientChangeToRemove is null)
            return;
        _context.OrderPizzaIngredientChanges.Remove(pizzaIngredientChangeToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderPizzaIngredientChange> AddOrderPizzaIngredientChangeAsync(OrderPizzaIngredientChange orderPizzaIngredientChange)
    {
        orderPizzaIngredientChange.Id = 0;
        var resultPizzaIngredientChange = await _context.OrderPizzaIngredientChanges.AddAsync(orderPizzaIngredientChange).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultPizzaIngredientChange.Entity;
    }

    public async Task<OrderPizzaIngredientChange> UpdateOrderPizzaIngredientChangeAsync(OrderPizzaIngredientChange orderPizzaIngredientChange)
    {
        var pizzaIngredientChangeToUpdate = await _context.OrderPizzaIngredientChanges.FindAsync(orderPizzaIngredientChange.Id).ConfigureAwait(false);
        if (pizzaIngredientChangeToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Pizza ingredient change with provided Id: {orderPizzaIngredientChange.Id} does not exist!");
        if (orderPizzaIngredientChange.OrderPizzaId != pizzaIngredientChangeToUpdate.OrderPizzaId)
            throw new ProvidedObjectNotValidException($"Provided order pizza Id: {orderPizzaIngredientChange.Id} does not match Id: {pizzaIngredientChangeToUpdate.Id}!");
        pizzaIngredientChangeToUpdate.ToChangeIngredientId = orderPizzaIngredientChange.ToChangeIngredientId;
        pizzaIngredientChangeToUpdate.ChangedIngredientId = orderPizzaIngredientChange.ChangedIngredientId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return pizzaIngredientChangeToUpdate;
    }
}
