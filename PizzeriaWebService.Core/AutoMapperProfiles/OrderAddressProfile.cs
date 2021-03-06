using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderAddressProfile : Profile
{
    public OrderAddressProfile()
    {
        CreateMap<OrderAddressDTO, OrderAddress>()
            .ForMember(dst=>dst.OrderPlacedId,opt=>opt.MapFrom(src=>src.OrderID));

        CreateMap<OrderAddress, OrderAddressDTO>()
            .ForMember(dst=>dst.OrderID,opt=>opt.MapFrom(src=>src.OrderPlacedId));
    }
}
