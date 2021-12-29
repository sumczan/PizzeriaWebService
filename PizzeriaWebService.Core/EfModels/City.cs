namespace PizzeriaWebService.Core.EfModels;

public partial class City
{
    public City()
    {
        ClientBlacklists = new HashSet<ClientBlacklist>();
        OrderAddresses = new HashSet<OrderAddress>();
    }

    public int Id { get; set; }
    public string CityName { get; set; } = null!;

    public virtual ICollection<ClientBlacklist> ClientBlacklists { get; set; }
    public virtual ICollection<OrderAddress> OrderAddresses { get; set; }
}
