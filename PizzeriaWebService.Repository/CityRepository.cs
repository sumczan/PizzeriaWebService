using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Repository;

public class CityRepository : ICityRepository
{
    private readonly PizzeriaDbContext _context;

    public CityRepository(PizzeriaDbContext context)
    {
        _context = context;
    }
}
