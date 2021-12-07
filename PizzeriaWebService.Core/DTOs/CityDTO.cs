using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public class CityDTO
{
    public int Id { get; set; }
    public string CityName { get; set; } = null!;
}
