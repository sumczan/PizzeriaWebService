using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Interfaces.Repositories;

public interface IOrderPizzaIngredientExtraRepository
{
    Task<OrderPizzaIngredientExtra> AddOrderPizzaIngredientExtraAsync(OrderPizzaIngredientExtra orderPizzaIngredientExtra);
    Task<OrderPizzaIngredientExtra> GetOrderPizzaIngredientExtraByIdAsync(int id);
    Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasAsync();
    Task<IEnumerable<OrderPizzaIngredientExtra>> GetOrderPizzaIngredientExtrasByOrderPizzaIdAsync(int orderPizzaId);
    Task RemoveOrderPizzaIngredientExtraAsync(int id);
    Task<OrderPizzaIngredientExtra> UpdateOrderPizzaIngredientExtraAsync(OrderPizzaIngredientExtra orderPizzaIngredientExtra);
}
