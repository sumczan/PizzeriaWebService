using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public  class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDTO>();
        //.ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id))
        //.ForMember(dto => dto.CityName, opt => opt.MapFrom(entity => entity.CityName));

        CreateMap<CityDTO, City>();
            //.ForMember(entity => entity.Id, opt => opt.MapFrom(dto => dto.Id))
            //.ForMember(entity => entity.CityName, opt => opt.MapFrom(dto => dto.CityName));
    }
}
