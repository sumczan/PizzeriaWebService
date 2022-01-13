using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public  class PizzaProfile : Profile
{
    public PizzaProfile()
    {
        CreateMap<Pizza, PizzaDTO>();
        CreateMap<PizzaDTO, Pizza>();
    }
}
