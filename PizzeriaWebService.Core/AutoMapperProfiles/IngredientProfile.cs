using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<IngredientDTO, Ingredient>();

        CreateMap<Ingredient, IngredientDTO>();
    }
}
