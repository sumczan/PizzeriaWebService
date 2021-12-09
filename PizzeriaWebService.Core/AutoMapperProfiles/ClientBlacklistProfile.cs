using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Exceptions;
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
            .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity.City));

        CreateMap<ClientBlacklistDTO, ClientBlacklist>();
    }
}
