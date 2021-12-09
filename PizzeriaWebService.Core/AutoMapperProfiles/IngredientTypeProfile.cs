using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class IngredientTypeProfile : Profile
{
    public IngredientTypeProfile()
    {
        CreateMap<IngredientType, IngredientTypeDTO>();
        
        CreateMap<IngredientTypeDTO, IngredientType>();
    }
}
