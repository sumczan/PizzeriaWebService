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
        CreateMap<Beverage, BeverageDTO>();
        //.ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id))
        //.ForMember(dto => dto.IsAlcoholic, opt => opt.MapFrom(entity => entity.IsAlcoholic))
        //.ForMember(dto => dto.BeverageName, opt => opt.MapFrom(entity => entity.BeverageName))
        //.ForMember(dto => dto.BeveragePrice, opt => opt.MapFrom(entity => entity.BeveragePrice));

        CreateMap<BeverageDTO, Beverage>();
            //.ForMember(entity => entity.Id, opt => opt.MapFrom(dto => dto.Id))
            //.ForMember(entity => entity.IsAlcoholic, opt => opt.MapFrom(dto => dto.IsAlcoholic))
            //.ForMember(entity => entity.BeverageName, opt => opt.MapFrom(dto => dto.BeverageName))
            //.ForMember(entity => entity.BeveragePrice, opt => opt.MapFrom(dto => dto.BeveragePrice));
    }
}
