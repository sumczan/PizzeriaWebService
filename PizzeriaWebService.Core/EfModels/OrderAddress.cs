namespace PizzeriaWebService.Core.EfModels;

public partial class OrderAddress
{
    public int OrderPlacedId { get; set; }
    public int CityId { get; set; }
    public string StreetName { get; set; } = null!;
    public string Apartment { get; set; } = null!;

    public virtual City City { get; set; } = null!;
    public virtual OrderPlaced OrderPlaced { get; set; } = null!;
}