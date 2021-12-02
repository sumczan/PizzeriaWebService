﻿using System;
using System.Collections.Generic;

namespace PizzeriaWebService.Core.EfModels;

public partial class OrderPizzaIngredientChange
{
    public int Id { get; set; }
    public int OrderPizzaId { get; set; }
    public int ToChangeIngredientId { get; set; }
    public int? ChangedIngredientId { get; set; }

    public virtual Ingredient? ChangedIngredient { get; set; }
    public virtual Ingredient ToChangeIngredient { get; set; } = null!;
}
