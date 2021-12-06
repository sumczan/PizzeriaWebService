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

public class OrderPizzaIngredientExtraRepository : IOrderPizzaIngredientExtraRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderPizzaIngredientExtraRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasAsync()
    {
        return await _context.OrderPizzaIngredientExtras.ToListAsync().ConfigureAwait(false);
    }
    public async Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(int orderPizzaId)
    {
        var pizzaIngredientExtras = await _context.OrderPizzaIngredientExtras.Where(x => x.OrderPizzaId == orderPizzaId).ToListAsync().ConfigureAwait(false);
        if (!pizzaIngredientExtras.Any())
            throw new RequestedItemDoesNotExistException($"Pizza ingredient extras with provided pizza order Id: {orderPizzaId} do not exist!");
        return pizzaIngredientExtras;
    }

    public async Task<OrderPizzaIngredientExtra> GetOrderPizzaIngredientExtraByIdAsync(int id)
    {
        var pizzaIngredientExtra = await _context.OrderPizzaIngredientExtras.FindAsync(id).ConfigureAwait(false);
        if (pizzaIngredientExtra is null)
            throw new RequestedItemDoesNotExistException($"Pizza ingredient extra with provided Id: {id} does not exist!");
        return pizzaIngredientExtra;
    }

    public async Task RemoveOrderPizzaIngredientExtraAsync(int id)
    {
        var pizzaIngredientExtraToRemove = await _context.OrderPizzaIngredientExtras.FindAsync(id).ConfigureAwait(false);
        if (pizzaIngredientExtraToRemove is null)
            return;
        _context.OrderPizzaIngredientExtras.Remove(pizzaIngredientExtraToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderPizzaIngredientExtra> AddOrderPizzaIngredientExtraAsync(OrderPizzaIngredientExtra orderPizzaIngredientExtra)
    {
        orderPizzaIngredientExtra.Id = 0;
        var resultPizzaIngredientExtra = await _context.OrderPizzaIngredientExtras.AddAsync(orderPizzaIngredientExtra).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultPizzaIngredientExtra.Entity;
    }

    public async Task<OrderPizzaIngredientExtra> UpdateOrderPizzaIngredientExtraAsync(OrderPizzaIngredientExtra orderPizzaIngredientExtra)
    {
        var pizzaIngredientExtraToUpdate = await _context.OrderPizzaIngredientExtras.FindAsync(orderPizzaIngredientExtra.Id).ConfigureAwait(false);
        if (pizzaIngredientExtraToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Pizza ingredient extra with provided Id: {orderPizzaIngredientExtra.Id} does not exist!");
        if (orderPizzaIngredientExtra.OrderPizzaId != pizzaIngredientExtraToUpdate.OrderPizzaId)
            throw new ProvidedObjectNotValidException(
                $"Provided pizza order Id: {orderPizzaIngredientExtra.OrderPizzaId} does not match Id: {pizzaIngredientExtraToUpdate.OrderPizzaId}!");
        pizzaIngredientExtraToUpdate.ExtraIngredientPrice = orderPizzaIngredientExtra.ExtraIngredientPrice;
        pizzaIngredientExtraToUpdate.IngredientId = orderPizzaIngredientExtra.IngredientId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return pizzaIngredientExtraToUpdate;
    }
}
