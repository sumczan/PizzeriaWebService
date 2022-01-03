using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public  class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDTO>();

        CreateMap<CityDTO, City>();
    }
}
