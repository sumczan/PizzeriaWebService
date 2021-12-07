using PizzeriaWebService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IBeverageService
{
    Task<IEnumerable<BeverageDTO>> GetBeveragesAsync();
}
