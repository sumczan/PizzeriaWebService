using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class OrderTypeProfile : Profile
{
    public OrderTypeProfile()
    {
        CreateMap<OrderTypeDTO, OrderType>();

        CreateMap<OrderType, OrderTypeDTO>();
    }
}
