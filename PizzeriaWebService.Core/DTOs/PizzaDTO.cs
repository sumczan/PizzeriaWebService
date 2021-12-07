using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public class PizzaDTO
{
    public int Id { get; set; }
    public string PizzaName { get; set; } = null!;
    public decimal PizzaPrice { get; set; }
    public IEnumerable<PizzaIngredientDTO> PizzaIngredients { get; set; } = null!;
}
