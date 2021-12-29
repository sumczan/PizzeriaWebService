using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class PizzaSizeService : IPizzaSizeService
{
    private readonly IPizzaSizeRepository _pizzaSizeRepository;
    private readonly IMapper _mapper;

    public PizzaSizeService(IPizzaSizeRepository pizzaSizeRepository, IMapper mapper)
    {
        _pizzaSizeRepository = pizzaSizeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PizzaSizeDTO>> GetPizzaSizesAsync()
    {
        var pizzaSizes = await _pizzaSizeRepository.GetPizzaSizesAsync().ConfigureAwait(false);
        var pizzaSizeDTOs = _mapper.Map<IEnumerable<PizzaSizeDTO>>(pizzaSizes);
        return pizzaSizeDTOs;
    }

    public async Task<PizzaSizeDTO> GetPizzaSizeByIdAsync(int id)
    {
        var pizzaSize = await _pizzaSizeRepository.GetPizzaSizeByIdAsync(id).ConfigureAwait(false);
        var pizzaSizeDTO = _mapper.Map<PizzaSizeDTO>(pizzaSize);
        return pizzaSizeDTO;
    }

    public async Task<PizzaSizeDTO> GetPizzaSizeByNameAsync(string sizeName)
    {
        var pizzaSize = await _pizzaSizeRepository.GetPizzaSizeByNameAsync(sizeName).ConfigureAwait(false);
        var pizzaSizeDTO = _mapper.Map<PizzaSizeDTO>(pizzaSize);
        return pizzaSizeDTO;
    }

    public async Task RemovePizzaSizeAsync(int id)
    {
        await _pizzaSizeRepository.RemovePizzaSizeAsync(id).ConfigureAwait(false);
    }

    public async Task<PizzaSizeDTO> AddPizzaSizeAsync(PizzaSizeDTO pizzaSizeDTO)
    {
        var pizzaSize = _mapper.Map<PizzaSize>(pizzaSizeDTO);
        pizzaSize = await _pizzaSizeRepository.AddPizzaSizeAsync(pizzaSize).ConfigureAwait(false);
        pizzaSizeDTO = _mapper.Map<PizzaSizeDTO>(pizzaSize);
        return pizzaSizeDTO;
    }

    public async Task<PizzaSizeDTO> UpdatePizzaSizeDTO(PizzaSizeDTO pizzaSizeDTO)
    {
        var pizzaSize = _mapper.Map<PizzaSize>(pizzaSizeDTO);
        pizzaSize = await _pizzaSizeRepository.UpdatePizzaSizeAsync(pizzaSize).ConfigureAwait(false);
        pizzaSizeDTO = _mapper.Map<PizzaSizeDTO>(pizzaSize);
        return pizzaSizeDTO;
    }
}
