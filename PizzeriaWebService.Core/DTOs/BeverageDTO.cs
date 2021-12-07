using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public  class BeverageDTO
{
    public int Id { get; set; }
    public string BeverageName { get; set; } = null!;
    public bool IsAlcoholic { get; set; }
    public decimal BeveragePrice { get; set; }
}
