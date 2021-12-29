namespace PizzeriaWebService.Core.DTOs;

public  class BeverageDTO
{
    public int Id { get; set; }
    public string BeverageName { get; set; } = null!;
    public bool IsAlcoholic { get; set; }
    public decimal BeveragePrice { get; set; }
}
