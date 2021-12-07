using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public class IngredientDTO
{
    public int Id { get; set; }
    public string IngredientName { get; set; } = null!;
    public IngredientTypeDTO IngredientType { get; set; } = null!;
    public decimal IngredientPrice { get; set; }
}
