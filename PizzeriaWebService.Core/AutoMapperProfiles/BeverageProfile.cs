using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public  class BeverageProfile : Profile
{
    public BeverageProfile()
    {
        CreateMap<Beverage, BeverageDTO>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id))
            .ForMember(dto => dto.IsAlcogolic, opt => opt.MapFrom(entity => entity.IsAlcoholic))
            .ForMember(dto => dto.BeverageName, opt => opt.MapFrom(entity => entity.BeverageName))
            .ForMember(dto => dto.BeveragePrice, opt => opt.MapFrom(entity => entity.BeveragePrice));
    }
}
