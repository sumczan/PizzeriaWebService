using System;
using System.Collections.Generic;

namespace PizzeriaWebService.Core.EfModels;

public partial class Beverage
{
    public Beverage()
    {
        OrderBeverages = new HashSet<OrderBeverage>();
    }

    public int Id { get; set; }
    public string BeverageName { get; set; } = null!;
    public bool IsAlcoholic { get; set; }
    public decimal BeveragePrice { get; set; }

    public virtual ICollection<OrderBeverage> OrderBeverages { get; set; }
}
