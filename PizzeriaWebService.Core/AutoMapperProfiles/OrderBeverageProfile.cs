using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderBeverageProfile : Profile
{
    public OrderBeverageProfile()
    {
        CreateMap<OrderBeverageDTO, OrderBeverage>()
            .ForMember(dst=>dst.OrderPlacedId, opt=>opt.MapFrom(src=>src.OrderId));

        CreateMap<OrderBeverage, OrderBeverageDTO>()
            .ForMember(dst => dst.OrderId, opt => opt.MapFrom(src => src.OrderPlacedId));
    }
}
