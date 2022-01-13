using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderPizzaIngredientExtraProfile : Profile
{
    public OrderPizzaIngredientExtraProfile()
    {
        CreateMap<OrderPizzaIngredientExtra, OrderPizzaIngredientExtraDTO>()
            .ForMember(dst => dst.ExtraIngredient, opt => opt.MapFrom(src => src.Ingredient));

        CreateMap<OrderPizzaIngredientExtraDTO, OrderPizzaIngredientExtra>()
            .ForMember(dst=>dst.IngredientId,opt=>opt.MapFrom(src=>src.ExtraIngredient.Id))
            .ForMember(dst => dst.Ingredient, opt => opt.Ignore())
            .ForMember(dst => dst.OrderPizza, opt => opt.Ignore());
    }
}