﻿using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IPizzaIngredientRepository
{
    Task<PizzaIngredient> AddPizzaIngredientAsync(PizzaIngredient pizzaIngredient);
    Task<PizzaIngredient> GetPizzaIngredientByIdAsync(int id);
    Task<IEnumerable<PizzaIngredient>> GetPizzaIngredientsAsync();
    Task<IEnumerable<PizzaIngredient>> GetPizzaIngredientsByIngredientIdAsync(int ingredientId);
    Task<IEnumerable<PizzaIngredient>> GetPizzaIngredientsByPizzaIdAsync(int pizzaId);
    Task RemovePizzaIngredientAsync(int id);
    Task<PizzaIngredient> UpdatePizzaIngredientAsync(PizzaIngredient pizzaIngredient);
}
