using PizzeriaWebService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
