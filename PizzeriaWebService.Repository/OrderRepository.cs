using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderPlaced>> GetOrdersAsync()
    {
        return await _context.OrderPlaceds
            .Include(x=>x.OrderStatus)
            .Include(x=>x.OrderType)
            .Include(x=>x.OrderAddress)
            .Include(x=>x.OrderBeverages)
                .ThenInclude(x=>x.Beverage)
            .Include(x=>x.OrderPizzas)
                .ThenInclude(x=>x.Pizza.PizzaIngredients)
                    .ThenInclude(x=>x.Ingredient.IngredientType)
            .Include(x=>x.OrderPizzas)
                .ThenInclude(x=>x.PizzaSize)
            .Include(x=>x.OrderPizzas)
                .ThenInclude(x=>x.OrderPizzaIngredientChanges)
                    .ThenInclude(x=>x.ChangedIngredient.IngredientType)
            .Include(x=>x.OrderPizzas)
                .ThenInclude(x=>x.OrderPizzaIngredientChanges)
                    .ThenInclude(x=>x.ToChangeIngredient.IngredientType)
            .Include(x=>x.OrderPizzas)
                .ThenInclude(x=>x.OrderPizzaIngredientExtras)
                    .ThenInclude(x=>x.Ingredient.IngredientType)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderPlaced>> GetOrdersByOrderTypeIdAsync(int orderTypeId)
    {
        var resultOrders = await _context.OrderPlaceds
            .Where(x => x.OrderTypeId == orderTypeId)
            .Include(x => x.OrderStatus)
            .Include(x => x.OrderType)
            .Include(x => x.OrderAddress)
            .Include(x => x.OrderBeverages)
                .ThenInclude(x => x.Beverage)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.Pizza.PizzaIngredients)
                    .ThenInclude(x => x.Ingredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.PizzaSize)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientChanges)
                    .ThenInclude(x => x.ChangedIngredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientChanges)
                    .ThenInclude(x => x.ToChangeIngredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientExtras)
                    .ThenInclude(x => x.Ingredient.IngredientType)
            .ToListAsync()
            .ConfigureAwait(false);
        if (!resultOrders.Any())
            throw new RequestedItemDoesNotExistException(
                $"Orders with provided order type Id: {orderTypeId} do not exist!");
        return resultOrders;
    }

    public async Task<IEnumerable<OrderPlaced>> GetOrdersByOrderStatusIdAsync(int orderStatusId)
    {
        var resultOrders = await _context.OrderPlaceds
            .Where(x=>x.OrderStatusId==orderStatusId)
            .Include(x => x.OrderStatus)
            .Include(x => x.OrderType)
            .Include(x => x.OrderAddress)
            .Include(x => x.OrderBeverages)
                .ThenInclude(x => x.Beverage)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.Pizza.PizzaIngredients)
                    .ThenInclude(x => x.Ingredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.PizzaSize)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientChanges)
                    .ThenInclude(x => x.ChangedIngredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientChanges)
                    .ThenInclude(x => x.ToChangeIngredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientExtras)
                    .ThenInclude(x => x.Ingredient.IngredientType)
            .ToListAsync()
            .ConfigureAwait(false);
        if (!resultOrders.Any())
            throw new RequestedItemDoesNotExistException(
                $"Orders with provided order status Id: {orderStatusId} do not exist!");
        return resultOrders;
    }

    public async Task<OrderPlaced> GetOrderByIdAsync(int id)
    {
        var resultOrder = await _context.OrderPlaceds
            .Include(x => x.OrderStatus)
            .Include(x => x.OrderType)
            .Include(x => x.OrderAddress)
            .Include(x => x.OrderBeverages)
                .ThenInclude(x => x.Beverage)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.Pizza.PizzaIngredients)
                    .ThenInclude(x => x.Ingredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.PizzaSize)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientChanges)
                    .ThenInclude(x => x.ChangedIngredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientChanges)
                    .ThenInclude(x => x.ToChangeIngredient.IngredientType)
            .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.OrderPizzaIngredientExtras)
                    .ThenInclude(x => x.Ingredient.IngredientType)
            .FirstOrDefaultAsync(x=>x.Id==id)
            .ConfigureAwait(false);
        if (resultOrder is null)
            throw new RequestedItemDoesNotExistException(
                $"Order with provided Id: {id} does not exist!");
        return resultOrder;
    } 

    public async Task RemoveOrderAsync(int id)
    {
        var orderToRemove = await _context.OrderPlaceds.FindAsync(id).ConfigureAwait(false);
        if (orderToRemove is null)
            return;
        _context.OrderPlaceds.Remove(orderToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderPlaced> AddOrderAsync(OrderPlaced order)
    {
        order.Id = 0;
        var resultOrder = await _context.OrderPlaceds.AddAsync(order).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetOrderByIdAsync(resultOrder.Entity.Id).ConfigureAwait(false);
    }

    public async Task<OrderPlaced> UpdateOrderAsync(OrderPlaced order)
    {
        var orderToUpdate = await _context.OrderPlaceds.FindAsync(order.Id).ConfigureAwait(false);
        if (orderToUpdate is null)
            throw new RequestedItemDoesNotExistException(
                $"Order with provided Id: {order.Id} does not exist!");
        if (DateTime.Compare(order.OrderTime, orderToUpdate.OrderTime) != 0)
            throw new ProvidedObjectNotValidException(
                $"Provided order, order time: {order.OrderTime} does not match: {orderToUpdate.OrderTime}!");

        orderToUpdate.OrderStatusId = order.OrderStatusId;
        orderToUpdate.OrderTypeId = order.OrderTypeId;
        orderToUpdate.PhoneNumber = order.PhoneNumber;
        orderToUpdate.OrderPrice = order.OrderPrice;
        orderToUpdate.ExtraInfo = order.ExtraInfo;

        await _context.SaveChangesAsync().ConfigureAwait(false);
        return await GetOrderByIdAsync(orderToUpdate.Id).ConfigureAwait(false);
    }
}
