using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.AutoMapperProfiles;

public class ClientBlacklistProfile : Profile
{
    public ClientBlacklistProfile()
    {
        CreateMap<ClientBlacklist, ClientBlacklistDTO>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id))
            .ForMember(dto => dto.Details, opt => opt.MapFrom(entity => entity.Details))
            .ForMember(dto => dto.Apartment, opt => opt.MapFrom(entity => entity.Apartment))
            .ForMember(dto => dto.StreetName, opt => opt.MapFrom(entity => entity.StreetName))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(entity => entity.PhoneNumber));

        CreateMap<CityDTO, ClientBlacklistDTO>()
            .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity));
    }
}
