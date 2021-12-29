namespace PizzeriaWebService.Core.DTOs;

public class OrderBeverageDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public BeverageDTO BeverageDTO { get; set; } = null!;
}
