using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

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
        return await _context.OrderPizzaIngredientExtras
            .Include(pi=>pi.Ingredient)
            .ToListAsync()
            .ConfigureAwait(false);
    }
    public async Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(int orderPizzaId)
    {
        var pizzaIngredientExtras = await _context.OrderPizzaIngredientExtras
            .Include(pi=>pi.Ingredient)
            .Where(x => x.OrderPizzaId == orderPizzaId)
            .ToListAsync()
            .ConfigureAwait(false);
        if (!pizzaIngredientExtras.Any())
            throw new RequestedItemDoesNotExistException($"Pizza ingredient extras with provided pizza order Id: {orderPizzaId} do not exist!");
        return pizzaIngredientExtras;
    }

    public async Task<OrderPizzaIngredientExtra> GetOrderPizzaIngredientExtraByIdAsync(int id)
    {
        var pizzaIngredientExtra = await _context.OrderPizzaIngredientExtras
            .Include(pi=>pi.Ingredient)
            .FirstOrDefaultAsync(x=>x.Id==id)
            .ConfigureAwait(false);
        return pizzaIngredientExtra ?? throw new RequestedItemDoesNotExistException($"Pizza ingredient extra with provided Id: {id} does not exist!");
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
        return await GetOrderPizzaIngredientExtraByIdAsync(resultPizzaIngredientExtra.Entity.Id).ConfigureAwait(false);
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
        return await GetOrderPizzaIngredientExtraByIdAsync(pizzaIngredientExtraToUpdate.Id).ConfigureAwait(false);
    }
}
