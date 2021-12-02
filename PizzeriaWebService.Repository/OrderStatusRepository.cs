using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Repository;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly PizzeriaDbContext _context;

    public OrderStatusRepository(PizzeriaDbContext context)
    {
        _context = context;
    }
}
