using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderStatusProfile : Profile
{
    public OrderStatusProfile()
    {
        CreateMap<OrderStatusDTO, OrderStatus>();

        CreateMap<OrderStatus, OrderStatusDTO>();
    }
}