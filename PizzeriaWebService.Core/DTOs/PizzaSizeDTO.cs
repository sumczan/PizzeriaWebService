namespace PizzeriaWebService.Core.DTOs;

public class PizzaSizeDTO
{
    public int Id { get; set; }
    public string SizeName { get; set; } = null!;
    public decimal PriceMultiplier { get; set; }
}
