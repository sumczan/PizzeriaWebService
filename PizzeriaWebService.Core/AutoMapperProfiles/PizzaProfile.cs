using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
