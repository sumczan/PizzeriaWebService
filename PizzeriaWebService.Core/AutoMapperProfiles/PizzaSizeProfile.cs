using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class PizzaSizeProfile : Profile
{
    public PizzaSizeProfile()
    {
        CreateMap<PizzaSizeDTO, PizzaSize>();

        CreateMap<PizzaSize, PizzaSizeDTO>();
    }
}
