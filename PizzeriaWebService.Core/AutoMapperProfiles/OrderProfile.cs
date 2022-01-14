using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderPlaced, OrderDTO>();

        CreateMap<OrderDTO, OrderPlaced>()
            .ForMember(dst => dst.OrderPizzas, opt => opt.Ignore())
            .ForMember(dst => dst.OrderBeverages, opt => opt.Ignore())
            .ForMember(dst => dst.OrderStatus, opt => opt.Ignore())
            .ForMember(dst => dst.OrderType, opt => opt.Ignore())
            .ForMember(dst => dst.OrderAddress, opt => opt.Ignore());
    }
}