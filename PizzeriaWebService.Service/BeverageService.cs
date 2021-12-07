using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Service;

public class BeverageService : IBeverageService
{
    private readonly IBeverageRepository _beverageRepository;
    private readonly IMapper _mapper;

    public BeverageService(IBeverageRepository beverageRepository, IMapper mapper)
    {
        _beverageRepository = beverageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BeverageDTO>> GetBeveragesAsync()
    {
        var beverages = await _beverageRepository.GetBeveragesAsync().ConfigureAwait(false);
        var beverageDTOs = _mapper.Map<IEnumerable<BeverageDTO>>(beverages);
        return beverageDTOs;
    }
}
