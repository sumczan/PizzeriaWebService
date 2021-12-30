using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class PizzaIngredientProfile : Profile
{
    public PizzaIngredientProfile()
    {
        CreateMap<PizzaIngredient, PizzaIngredientDTO>();

        CreateMap<PizzaIngredientDTO, PizzaIngredient>();
    }
}