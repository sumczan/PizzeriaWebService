using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public  class BeverageProfile : Profile
{
    public BeverageProfile()
    {
        CreateMap<Beverage, BeverageDTO>();

        CreateMap<BeverageDTO, Beverage>();
    }
}
