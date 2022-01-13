using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class OrderPizzaRepository : IOrderPizzaRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderPizzaRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderPizza>> GetOrderPizzasAsync()
    {
        return await _context.OrderPizzas
            .Include(x => x.Pizza.PizzaIngredients).ThenInclude(x => x.Ingredient.IngredientType)
            .Include(x => x.PizzaSize)
            .Include(x => x.OrderPizzaIngredientChanges).ThenInclude(x => x.ToChangeIngredient.IngredientType)
            .Include(x => x.OrderPizzaIngredientChanges).ThenInclude(x => x.ChangedIngredient.IngredientType)
            .Include(x => x.OrderPizzaIngredientExtras).ThenInclude(x => x.Ingredient.IngredientType)
            .ToListAsync()
            .ConfigureAwait(false);

    }

    public async Task<IEnumerable<OrderPizza>> GetOrderPizzasByOrderPlacedIdAsync(int orderPlacedId)
    {
        var resultOrderPizzas = await _context.OrderPizzas
            .Include(x => x.Pizza.PizzaIngredients).ThenInclude(x => x.Ingredient.IngredientType)
            .Include(x => x.PizzaSize)
            .Include(x => x.OrderPizzaIngredientChanges).ThenInclude(x => x.ToChangeIngredient.IngredientType)
            .Include(x => x.OrderPizzaIngredientChanges).ThenInclude(x => x.ChangedIngredient.IngredientType)
            .Include(x => x.OrderPizzaIngredientExtras).ThenInclude(x => x.Ingredient.IngredientType)
            .Where(x=>x.OrderPlacedId==orderPlacedId)
            .ToListAsync()
            .ConfigureAwait(false);
        if (!resultOrderPizzas.Any())
            throw new RequestedItemDoesNotExistException($"Order pizzas with provided order placed Id: {orderPlacedId} do not exist!");
        return resultOrderPizzas;
    }

    public async Task<OrderPizza> GetOrderPizzaByIdAsync(int id)
    {
        var resultOrderPizza = await _context.OrderPizzas
            .Include(x => x.Pizza.PizzaIngredients).ThenInclude(x => x.Ingredient.IngredientType)
            .Include(x => x.PizzaSize)
            .Include(x => x.OrderPizzaIngredientChanges).ThenInclude(x => x.ToChangeIngredient.IngredientType)
            .Include(x => x.OrderPizzaIngredientChanges).ThenInclude(x => x.ChangedIngredient.IngredientType)
            .Include(x => x.OrderPizzaIngredientExtras).ThenInclude(x => x.Ingredient.IngredientType)
            .FirstOrDefaultAsync(x=>x.Id==id)
            .ConfigureAwait(false);
        return resultOrderPizza ?? throw new RequestedItemDoesNotExistException($"Order pizza with provided Id: {id} does not exist!");
    }

    public async Task RemoveOrderPizzaAsync(int id)
    {
        var orderPizzaToRemove = await _context.OrderPizzas.FindAsync(id).ConfigureAwait(false);
        if (orderPizzaToRemove is null)
            return;
        _context.OrderPizzas.Remove(orderPizzaToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderPizza> AddOrderPizzaAsync(OrderPizza orderPizza)
    {
        orderPizza.Id = 0;
        //orderPizza.OrderPlaced = null;
        //orderPizza.OrderPizzaIngredientChanges = null;
        //orderPizza.OrderPizzaIngredientExtras = null;
        //orderPizza.Pizza = null;
        //orderPizza.PizzaSize = null;
        var resultOrderPizza = await _context.OrderPizzas.AddAsync(orderPizza).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetOrderPizzaByIdAsync(resultOrderPizza.Entity.Id).ConfigureAwait(false);
    }

    public async Task<OrderPizza> UpdateOrderPizzaAsync(OrderPizza orderPizza)
    {
        var orderPizzaToUpdate = await _context.OrderPizzas.FindAsync(orderPizza.Id).ConfigureAwait(false);
        if(orderPizzaToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Order pizza with provided Id: {orderPizza.Id} does not exist!");
        if (orderPizza.OrderPlacedId != orderPizzaToUpdate.OrderPlacedId)
            throw new ProvidedObjectNotValidException($"Provided order placed Id: {orderPizza.OrderPlacedId} does not match Id: {orderPizzaToUpdate.OrderPlacedId}!");
        orderPizzaToUpdate.OrderPizzaPrice = orderPizza.OrderPizzaPrice;
        orderPizzaToUpdate.PizzaSizeId = orderPizza.PizzaSizeId;
        orderPizzaToUpdate.PizzaId = orderPizza.PizzaId;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetOrderPizzaByIdAsync(orderPizzaToUpdate.Id).ConfigureAwait(false);
    }
}
