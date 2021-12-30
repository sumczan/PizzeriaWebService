using AutoMapper;
using PizzeriaWebService.Core.DTOs;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;

namespace PizzeriaWebService.Service;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;
    private readonly IMapper _mapper;

    public PizzaService(IPizzaRepository pizzaRepository, IMapper mapper)
    {
        _pizzaRepository = pizzaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PizzaDTO>> GetPizzasAsync()
    {
        var pizzas = await _pizzaRepository
            .GetPizzasAsync()
            .ConfigureAwait(false);
        var pizzaDTOs = _mapper.Map<IEnumerable<PizzaDTO>>(pizzas);
        return pizzaDTOs;
    }

    public async Task<PizzaDTO> GetPizzaByIdAsync(int id)
    {
        var pizza = await _pizzaRepository
            .GetPizzaByIdAsync(id)
            .ConfigureAwait(false);
        var pizzaDTO = _mapper.Map<PizzaDTO>(pizza);
        return pizzaDTO;
    }

    public async Task<PizzaDTO> GetPizzaByNameAsync(string pizzaName)
    {
        var pizza = await _pizzaRepository
            .GetPizzaByNameAsync(pizzaName)
            .ConfigureAwait(false);
        var pizzaDTO = _mapper.Map<PizzaDTO>(pizza);
        return pizzaDTO;
    }

    public async Task RemovePizzaAsync(int id)
    {
        await _pizzaRepository.RemovePizzaAsync(id).ConfigureAwait(false);
    }

    public async Task<PizzaDTO> AddPizzaAsync(PizzaDTO pizzaDTO)
    {
        var pizza = _mapper.Map<Pizza>(pizzaDTO);
        pizza = await _pizzaRepository
            .AddPizzaAsync(pizza)
            .ConfigureAwait(false);
        pizzaDTO = _mapper.Map<PizzaDTO>(pizza);
        return pizzaDTO;
    }

    public async Task<PizzaDTO> UpdatePizzaAsync(PizzaDTO pizzaDTO)
    {
        var pizza = _mapper.Map<Pizza>(pizzaDTO);
        pizza = await _pizzaRepository
            .UpdatePizzaAsync(pizza)
            .ConfigureAwait(false);
        pizzaDTO = _mapper.Map<PizzaDTO>(pizza);
        return pizzaDTO;
    }
}
