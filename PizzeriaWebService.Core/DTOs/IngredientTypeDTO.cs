using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public  class IngredientTypeDTO
{
    public int Id { get; set; }
    public string IngredientTypeName { get; set; } = null!;
    public bool IsVegan { get; set; }
    public bool IsMeat { get; set; }
    public bool IsVegetable { get; set; }
    public bool IsGlutenFree { get; set; }
    public bool IsDairy { get; set; }
}
