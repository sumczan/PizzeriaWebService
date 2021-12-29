namespace PizzeriaWebService.Core.EfModels;

public partial class IngredientType
{
    public IngredientType()
    {
        Ingredients = new HashSet<Ingredient>();
    }

    public int Id { get; set; }
    public string IngredientTypeName { get; set; } = null!;
    public bool IsVegan { get; set; }
    public bool IsMeat { get; set; }
    public bool IsVegetable { get; set; }
    public bool IsGlutenFree { get; set; }
    public bool IsDairy { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; }
}
