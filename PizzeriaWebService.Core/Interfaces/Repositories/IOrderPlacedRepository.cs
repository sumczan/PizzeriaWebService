﻿using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPlacedRepository
{
    Task<IEnumerable<OrderPlaced>> GetOrderPlacedsAsync();
}
