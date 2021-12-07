using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public class OrderPizzaIngredientChangeDTO
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public IngredientDTO ToChangeIngredient { get; set; } = null!;
    public IngredientDTO? ChangedIngredient { get; set; }
}
