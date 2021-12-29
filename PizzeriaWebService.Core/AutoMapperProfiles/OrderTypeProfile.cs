using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderTypeProfile : Profile
{
    public OrderTypeProfile()
    {
        CreateMap<OrderTypeDTO, OrderType>();

        CreateMap<OrderType, OrderTypeDTO>();
    }
}
