using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class IngredientTypeProfile : Profile
{
    public IngredientTypeProfile()
    {
        CreateMap<IngredientType, IngredientTypeDTO>();
        
        CreateMap<IngredientTypeDTO, IngredientType>();
    }
}
