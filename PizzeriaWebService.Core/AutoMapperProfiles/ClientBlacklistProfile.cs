using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class ClientBlacklistProfile : Profile
{
    public ClientBlacklistProfile()
    {
        CreateMap<ClientBlacklist, ClientBlacklistDTO>();

        CreateMap<ClientBlacklistDTO, ClientBlacklist>()
            .ForMember(entity => entity.CityId, opt => opt.MapFrom(dto => dto.City.Id));
    }
}
