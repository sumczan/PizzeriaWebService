using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class OrderPlacedRepository : IOrderPlacedRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderPlacedRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderPlaced>> GetOrderPlacedsAsync()
    {
        return await _context.OrderPlaceds.ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderPlaced>> GetOrderPlacedsByOrderTypeIdAsync(int orderTypeId)
    {
        var resultOrderPlaceds = await _context.OrderPlaceds.Where(x => x.OrderTypeId == orderTypeId).ToListAsync().ConfigureAwait(false);
        if (!resultOrderPlaceds.Any())
            throw new RequestedItemDoesNotExistException($"Order placeds with provided order type Id: {orderTypeId} do not exist!");
        return resultOrderPlaceds;
    }

    public async Task<IEnumerable<OrderPlaced>> GetOrderPlacedsByOrderStatusIdAsync(int orderStatusId)
    {
        var resultOrderPlaceds = await _context.OrderPlaceds.Where(x=>x.OrderStatusId==orderStatusId).ToListAsync().ConfigureAwait(false);
        if (!resultOrderPlaceds.Any())
            throw new RequestedItemDoesNotExistException($"Order placeds with provided order status Id: {orderStatusId} do not exis!");
        return resultOrderPlaceds;
    }

    public async Task<OrderPlaced> GetOrderPlacedByIdAsync(int id)
    {
        var resultOrderPlaced = await _context.OrderPlaceds.FindAsync(id).ConfigureAwait(false);
        if (resultOrderPlaced is null)
            throw new RequestedItemDoesNotExistException($"Order placed with provided Id: {id} does not exist!");
        return resultOrderPlaced;
    } 

    public async Task RemoveOrderPlacedAsync(int id)
    {
        var orderPlacedToRemove = await _context.OrderPlaceds.FindAsync(id).ConfigureAwait(false);
        if (orderPlacedToRemove is null)
            return;
        _context.OrderPlaceds.Remove(orderPlacedToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderPlaced> AddOrderPlacedAsync(OrderPlaced orderPlaced)
    {
        orderPlaced.Id = 0;
        var resultOrderPlaced = await _context.OrderPlaceds.AddAsync(orderPlaced).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultOrderPlaced.Entity;
    }

    public async Task<OrderPlaced> UpdateOrderPlacedAsync(OrderPlaced orderPlaced)
    {
        var orderPlacedToUpdate = await _context.OrderPlaceds.FindAsync(orderPlaced.Id).ConfigureAwait(false);
        if (orderPlacedToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Order placed with provided Id: {orderPlaced.Id} does not exist!");
        if (DateTime.Compare(orderPlaced.OrderTime, orderPlacedToUpdate.OrderTime) != 0)
            throw new ProvidedObjectNotValidException($"Provided order placed order time: {orderPlaced.OrderTime} does not match: {orderPlacedToUpdate.OrderTime}!");
        orderPlacedToUpdate.OrderStatusId = orderPlaced.OrderStatusId;
        orderPlacedToUpdate.OrderTypeId = orderPlaced.OrderTypeId;
        orderPlacedToUpdate.PhoneNumber = orderPlaced.PhoneNumber;
        orderPlacedToUpdate.OrderPrice = orderPlaced.OrderPrice;
        orderPlacedToUpdate.ExtraInfo = orderPlaced.ExtraInfo;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return orderPlacedToUpdate;
    }
}
