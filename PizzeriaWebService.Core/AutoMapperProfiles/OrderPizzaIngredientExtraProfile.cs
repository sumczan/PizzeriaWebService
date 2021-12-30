using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderPizzaIngredientExtraProfile : Profile
{
    public OrderPizzaIngredientExtraProfile()
    {
        CreateMap<OrderPizzaIngredientExtra, OrderPizzaIngredientExtraDTO>();
        CreateMap<OrderPizzaIngredientExtraDTO, OrderPizzaIngredientExtra>();
    }
}