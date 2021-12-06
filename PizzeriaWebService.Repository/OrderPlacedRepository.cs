using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
