using PizzeriaWebService.Core.DTOs;

namespace PizzeriaWebService.Core.Interfaces.Services;

public interface IBeverageService
{
    Task<BeverageDTO> AddBeverageAsync(BeverageDTO beverageDTO);
    Task<IEnumerable<BeverageDTO>> GetAlcoholicBeveragesAsync();
    Task<BeverageDTO> GetBeverageByIdAsync(int id);
    Task<BeverageDTO> GetBeverageByNameAsync(string beverageName);
    Task<IEnumerable<BeverageDTO>> GetBeveragesAsync();
    Task<IEnumerable<BeverageDTO>> GetNonAlcoholicBeveragesAsync();
    Task RemoveBeverageAsync(int id);
    Task<BeverageDTO> UpdateBeverageAsync(BeverageDTO beverageDTO);
}
