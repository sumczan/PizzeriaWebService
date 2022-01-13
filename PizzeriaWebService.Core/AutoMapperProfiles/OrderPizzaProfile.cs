using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderPizzaProfile : Profile
{
    public OrderPizzaProfile()
    {
        CreateMap<OrderPizza, OrderPizzaDTO>()
            .ForMember(dst => dst.OrderId, opt => opt.MapFrom(src => src.OrderPlacedId))
            .ForMember(dst => dst.PizzaPrice, opt => opt.MapFrom(src => src.OrderPizzaPrice))
            .ForMember(dst => dst.PizzaIngredientExtras, opt => opt.MapFrom(src => src.OrderPizzaIngredientExtras))
            .ForMember(dst => dst.PizzaIngredientChanges, opt => opt.MapFrom(src => src.OrderPizzaIngredientChanges));

        CreateMap<OrderPizzaDTO, OrderPizza>()
            .ForMember(dst => dst.OrderPlacedId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dst => dst.OrderPizzaPrice, opt => opt.MapFrom(src => src.PizzaPrice))
            .ForMember(dst => dst.OrderPizzaIngredientChanges, opt => opt.Ignore())
            .ForMember(dst => dst.OrderPizzaIngredientExtras, opt => opt.Ignore())
            .ForMember(dst => dst.Pizza, opt => opt.Ignore())
            .ForMember(dst => dst.PizzaSize, opt => opt.Ignore())
            .ForMember(dst => dst.OrderPlaced, opt => opt.Ignore());
    }
}