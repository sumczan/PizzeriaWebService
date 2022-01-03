using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderPizzaIngredientChangeProfile : Profile
{
    public OrderPizzaIngredientChangeProfile()
    {
        CreateMap<OrderPizzaIngredientChange, OrderPizzaIngredientChangeDTO>();
        CreateMap<OrderPizzaIngredientChangeDTO, OrderPizzaIngredientChange>();
    }
}