namespace PizzeriaWebService.Core.EfModels;

public partial class OrderBeverage
{
    public int Id { get; set; }
    public int OrderPlacedId { get; set; }
    public int BeverageId { get; set; }
    public decimal OrderBeveragePrice { get; set; }

    public virtual Beverage Beverage { get; set; } = null!;
    public virtual OrderPlaced OrderPlaced { get; set; } = null!;
}