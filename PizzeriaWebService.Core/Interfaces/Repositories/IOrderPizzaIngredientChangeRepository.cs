using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPizzaIngredientChangeRepository
{
    Task<OrderPizzaIngredientChange> AddOrderPizzaIngredientChangeAsync(OrderPizzaIngredientChange orderPizzaIngredientChange);
    Task<OrderPizzaIngredientChange> GetOrderPizzaIngredientChangeByIdAsync(int id);
    Task<IEnumerable<OrderPizzaIngredientChange>> GetOrderPizzaIngredientChangesAsync();
    Task<IEnumerable<OrderPizzaIngredientChange>> GetOrderPizzaIngredientChangesByOrderPizzaIdAsync(int orderPizzaId);
    Task RemoveOrderPizzaIngredientChangeAsync(int id);
    Task<OrderPizzaIngredientChange> UpdateOrderPizzaIngredientChangeAsync(OrderPizzaIngredientChange orderPizzaIngredientChange);
}
