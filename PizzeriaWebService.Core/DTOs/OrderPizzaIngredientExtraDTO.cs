using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaIngredientExtraDTO
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public IngredientDTO ExtraIngredient { get; set; } = null!;
    public decimal ExtraIngredientPrice { get; set; }
}
