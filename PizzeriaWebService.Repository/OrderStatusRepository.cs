using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
using PizzeriaWebService.Core.Interfaces.Repositories;

namespace PizzeriaWebService.Repository;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderStatusRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderStatus>> GetOrderStatusesAsync()
    {
        return await _context.OrderStatuses.ToListAsync().ConfigureAwait(false);
    }

    public async Task<OrderStatus> GetOrderStatusByIdAsync(int id)
    {
        var resultOrderStatus = await _context.OrderStatuses.FindAsync(id).ConfigureAwait(false);
        return resultOrderStatus ?? throw new RequestedItemDoesNotExistException($"Order staus with provided Id: {id} does not exist!");
    }

    public async Task<OrderStatus> GetOrderStatusByNameAsync(string statusName)
    {
        var resultOrderStatus = await _context.OrderStatuses.FirstOrDefaultAsync(x=>x.StatusName==statusName).ConfigureAwait(false);
        return resultOrderStatus ?? throw new RequestedItemDoesNotExistException($"Order status with provided name: {statusName} does not exist!");
    }

    public async Task RemoveOrderStatusAsync(int id)
    {
        var orderStatusToRemove = await _context.OrderStatuses.FindAsync(id).ConfigureAwait(false);
        if (orderStatusToRemove is null)
            return;
        _context.OrderStatuses.Remove(orderStatusToRemove);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<OrderStatus> AddOrderStatusAsync(OrderStatus orderStatus)
    {
        orderStatus.Id = 0;
        var orderStatusFromDb = await _context.OrderStatuses.FirstOrDefaultAsync(x=>x.StatusName==orderStatus.StatusName).ConfigureAwait(false);
        if (orderStatusFromDb is not null)
            throw new ProvidedItemAlreadyExistsException($"Order status with provided name: {orderStatus.StatusName} already exists!");
        var resultOrderStatus = await _context.OrderStatuses.AddAsync(orderStatus).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return resultOrderStatus.Entity;
    }

    public async Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus)
    {
        var orderStatusToUpdate = await _context.OrderStatuses.FindAsync(orderStatus.Id).ConfigureAwait(false);
        if (orderStatusToUpdate is null)
            throw new RequestedItemDoesNotExistException($"Order status with provided Id: {orderStatus.Id} does not exist!");
        if (!Equals(orderStatus.StatusName, orderStatusToUpdate.StatusName))
            if (await _context.OrderStatuses.FirstOrDefaultAsync(x => x.StatusName == orderStatus.StatusName) is not null)
                throw new ProvidedItemAlreadyExistsException($"Order status with provided name: {orderStatus.StatusName} already exists!");
        orderStatusToUpdate.StatusName = orderStatus.StatusName;
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return orderStatusToUpdate;
    }
}
