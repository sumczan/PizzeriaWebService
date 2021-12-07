﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.DTOs;

public class PizzaIngredientDTO
{
    public int Id { get; set; }
    public int PizzaId { get; set; }
    public IngredientDTO Ingredient { get; set; } = null!;
}
