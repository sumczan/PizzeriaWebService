using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IPizzaSizeService
{
    Task<PizzaSizeDTO> AddPizzaSizeAsync(PizzaSizeDTO pizzaSizeDTO);
    Task<PizzaSizeDTO> GetPizzaSizeByIdAsync(int id);
    Task<PizzaSizeDTO> GetPizzaSizeByNameAsync(string sizeName);
    Task<IEnumerable<PizzaSizeDTO>> GetPizzaSizesAsync();
    Task RemovePizzaSizeAsync(int id);
    Task<PizzaSizeDTO> UpdatePizzaSizeDTO(PizzaSizeDTO pizzaSizeDTO);
}
