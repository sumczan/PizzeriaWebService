using Microsoft.EntityFrameworkCore;

namespace PizzeriaWebService.Core.EfModels;

public partial class PizzeriaDbContext : DbContext
{
    public PizzeriaDbContext()
    {
    }

    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beverage> Beverages { get; set; } = null!;
    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<ClientBlacklist> ClientBlacklists { get; set; } = null!;
    public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
    public virtual DbSet<IngredientType> IngredientTypes { get; set; } = null!;
    public virtual DbSet<OrderAddress> OrderAddresses { get; set; } = null!;
    public virtual DbSet<OrderBeverage> OrderBeverages { get; set; } = null!;
    public virtual DbSet<OrderPizza> OrderPizzas { get; set; } = null!;
    public virtual DbSet<OrderPizzaIngredientChange> OrderPizzaIngredientChanges { get; set; } = null!;
    public virtual DbSet<OrderPizzaIngredientExtra> OrderPizzaIngredientExtras { get; set; } = null!;
    public virtual DbSet<OrderPlaced> OrderPlaceds { get; set; } = null!;
    public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
    public virtual DbSet<OrderType> OrderTypes { get; set; } = null!;
    public virtual DbSet<Pizza> Pizzas { get; set; } = null!;
    public virtual DbSet<PizzaIngredient> PizzaIngredients { get; set; } = null!;
    public virtual DbSet<PizzaSize> PizzaSizes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PizzeriaDb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Name=Database");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beverage>(entity =>
        {
            entity.ToTable("Beverage");

            entity.HasIndex(e => e.BeverageName, "UQ_Beverage_BeverageName")
                .IsUnique();

            entity.Property(e => e.BeverageName)
                .HasMaxLength(100)
                .HasColumnName("Beverage_Name");

            entity.Property(e => e.BeveragePrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Beverage_Price");

            entity.Property(e => e.IsAlcoholic).HasColumnName("isAlcoholic");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.HasIndex(e => e.CityName, "UQ_City_CityName")
                .IsUnique();

            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .HasColumnName("City_Name");
        });

        modelBuilder.Entity<ClientBlacklist>(entity =>
        {
            entity.ToTable("Client_Blacklist");

            entity.Property(e => e.Apartment).HasMaxLength(100);

            entity.Property(e => e.CityId).HasColumnName("City_Id");

            entity.Property(e => e.Details).HasMaxLength(1000);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("Phone_Number");

            entity.Property(e => e.StreetName)
                .HasMaxLength(100)
                .HasColumnName("Street_Name");

            entity.HasOne(d => d.City)
                .WithMany(p => p.ClientBlacklists)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_ClientBlacklist_City");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredient");

            entity.HasIndex(e => e.IngredientName, "UQ_Ingredient_IngredientName")
                .IsUnique();

            entity.Property(e => e.IngredientName)
                .HasMaxLength(100)
                .HasColumnName("Ingredient_Name");

            entity.Property(e => e.IngredientPrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Ingredient_price");

            entity.Property(e => e.IngredientTypeId).HasColumnName("Ingredient_Type_Id");

            entity.HasOne(d => d.IngredientType)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.IngredientTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingredient_IngredientType");
        });

        modelBuilder.Entity<IngredientType>(entity =>
        {
            entity.ToTable("Ingredient_Type");

            entity.HasIndex(e => e.IngredientTypeName, "UQ_IngredientType_IngredientTypeName")
                .IsUnique();

            entity.Property(e => e.IngredientTypeName)
                .HasMaxLength(100)
                .HasColumnName("Ingredient_type_name");

            entity.Property(e => e.IsDairy).HasColumnName("isDairy");

            entity.Property(e => e.IsGlutenFree).HasColumnName("isGlutenFree");

            entity.Property(e => e.IsMeat).HasColumnName("isMeat");

            entity.Property(e => e.IsVegan).HasColumnName("isVegan");

            entity.Property(e => e.IsVegetable).HasColumnName("isVegetable");
        });

        modelBuilder.Entity<OrderAddress>(entity =>
        {
            entity.HasKey(e => e.OrderPlacedId)
                .HasName("PK_OrderAddress");

            entity.ToTable("Order_Address");

            entity.Property(e => e.OrderPlacedId)
                .ValueGeneratedNever()
                .HasColumnName("Order_Placed_Id");

            entity.Property(e => e.Apartment).HasMaxLength(100);

            entity.Property(e => e.CityId).HasColumnName("City_Id");

            entity.Property(e => e.StreetName)
                .HasMaxLength(100)
                .HasColumnName("Street_Name");

            entity.HasOne(d => d.City)
                .WithMany(p => p.OrderAddresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderAddress_City");

            entity.HasOne(d => d.OrderPlaced)
                .WithOne(p => p.OrderAddress)
                .HasForeignKey<OrderAddress>(d => d.OrderPlacedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderAddress_OrderPlaced");
        });

        modelBuilder.Entity<OrderBeverage>(entity =>
        {
            entity.ToTable("Order_Beverage");

            entity.Property(e => e.BeverageId).HasColumnName("Beverage_Id");

            entity.Property(e => e.OrderBeveragePrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Order_Beverage_Price");

            entity.Property(e => e.OrderPlacedId).HasColumnName("Order_Placed_Id");

            entity.HasOne(d => d.Beverage)
                .WithMany(p => p.OrderBeverages)
                .HasForeignKey(d => d.BeverageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderBeverage_Beverage");

            entity.HasOne(d => d.OrderPlaced)
                .WithMany(p => p.OrderBeverages)
                .HasForeignKey(d => d.OrderPlacedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderBeverage_OrderPlaced");
        });

        modelBuilder.Entity<OrderPizza>(entity =>
        {
            entity.ToTable("Order_Pizza");

            entity.Property(e => e.OrderPizzaPrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Order_Pizza_Price");

            entity.Property(e => e.OrderPlacedId).HasColumnName("Order_Placed_Id");

            entity.Property(e => e.PizzaId).HasColumnName("Pizza_Id");

            entity.Property(e => e.PizzaSizeId).HasColumnName("Pizza_Size_Id");

            entity.HasOne(d => d.OrderPlaced)
                .WithMany(p => p.OrderPizzas)
                .HasForeignKey(d => d.OrderPlacedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizza_OrderPlaced");

            entity.HasOne(d => d.Pizza)
                .WithMany(p => p.OrderPizzas)
                .HasForeignKey(d => d.PizzaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizza_Pizza");

            entity.HasOne(d => d.PizzaSize)
                .WithMany(p => p.OrderPizzas)
                .HasForeignKey(d => d.PizzaSizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizza_PizzaSize");
        });

        modelBuilder.Entity<OrderPizzaIngredientChange>(entity =>
        {
            entity.ToTable("Order_Pizza_Ingredient_Change");

            entity.Property(e => e.ChangedIngredientId).HasColumnName("Changed_Ingredient_Id");

            entity.Property(e => e.OrderPizzaId).HasColumnName("Order_Pizza_Id");

            entity.Property(e => e.ToChangeIngredientId).HasColumnName("To_Change_Ingredient_Id");

            entity.HasOne(d => d.ChangedIngredient)
                .WithMany(p => p.OrderPizzaIngredientChangeChangedIngredients)
                .HasForeignKey(d => d.ChangedIngredientId)
                .HasConstraintName("FK_OrderPizzaIngredientChange_Ingredient_Changed");

            entity.HasOne(d => d.OrderPizza)
                .WithMany(p => p.OrderPizzaIngredientChanges)
                .HasForeignKey(d => d.OrderPizzaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizzaIngredientChange_OrderPizza");

            entity.HasOne(d => d.ToChangeIngredient)
                .WithMany(p => p.OrderPizzaIngredientChangeToChangeIngredients)
                .HasForeignKey(d => d.ToChangeIngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizzaIngredientChange_Ingredient_ToChange");
        });

        modelBuilder.Entity<OrderPizzaIngredientExtra>(entity =>
        {
            entity.ToTable("Order_Pizza_Ingredient_Extra");

            entity.Property(e => e.ExtraIngredientPrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Extra_Ingredient_Price");

            entity.Property(e => e.IngredientId).HasColumnName("Ingredient_Id");

            entity.Property(e => e.OrderPizzaId).HasColumnName("Order_Pizza_Id");

            entity.HasOne(d => d.Ingredient)
                .WithMany(p => p.OrderPizzaIngredientExtras)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizzaIngredientExtra_Ingredient");

            entity.HasOne(d => d.OrderPizza)
                .WithMany(p => p.OrderPizzaIngredientExtras)
                .HasForeignKey(d => d.OrderPizzaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPizzaIngredientExtra_OrderPizza");
        });

        modelBuilder.Entity<OrderPlaced>(entity =>
        {
            entity.ToTable("Order_Placed");

            entity.Property(e => e.ExtraInfo)
                .HasMaxLength(500)
                .HasColumnName("Extra_Info");

            entity.Property(e => e.OrderPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Order_Price");

            entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_Id");

            entity.Property(e => e.OrderTime)
                .HasColumnType("smalldatetime")
                .HasColumnName("Order_Time");

            entity.Property(e => e.OrderTypeId).HasColumnName("Order_Type_Id");

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("Phone_Number");

            entity.HasOne(d => d.OrderStatus)
                .WithMany(p => p.OrderPlaceds)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPlaced_OrderStatus");

            entity.HasOne(d => d.OrderType)
                .WithMany(p => p.OrderPlaceds)
                .HasForeignKey(d => d.OrderTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPlaced_OrderType");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("Order_Status");

            entity.HasIndex(e => e.StatusName, "UQ_OrderStatus_StatusName")
                .IsUnique();

            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .HasColumnName("Status_Name");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.ToTable("Order_Type");

            entity.HasIndex(e => e.OrderTypeName, "UQ_OrderType_OrderTypeName")
                .IsUnique();

            entity.Property(e => e.OrderTypeName)
                .HasMaxLength(100)
                .HasColumnName("Order_Type_Name");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.ToTable("Pizza");

            entity.HasIndex(e => e.PizzaName, "UQ_Pizza_PizzaName")
                .IsUnique();

            entity.Property(e => e.PizzaName)
                .HasMaxLength(100)
                .HasColumnName("Pizza_Name");

            entity.Property(e => e.PizzaPrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Pizza_Price");
        });

        modelBuilder.Entity<PizzaIngredient>(entity =>
        {
            entity.ToTable("Pizza_Ingredient");

            entity.Property(e => e.IngredientId).HasColumnName("Ingredient_Id");

            entity.Property(e => e.PizzaId).HasColumnName("Pizza_Id");

            entity.HasOne(d => d.Ingredient)
                .WithMany(p => p.PizzaIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PizzaIngredient_Ingredient");

            entity.HasOne(d => d.Pizza)
                .WithMany(p => p.PizzaIngredients)
                .HasForeignKey(d => d.PizzaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PizzaIngredient_Pizza");
        });

        modelBuilder.Entity<PizzaSize>(entity =>
        {
            entity.ToTable("Pizza_Size");

            entity.HasIndex(e => e.SizeName, "UQ_PizzaSize_SizeName")
                .IsUnique();

            entity.Property(e => e.PriceMultiplier)
                .HasColumnType("decimal(4, 3)")
                .HasColumnName("Price_Multiplier");

            entity.Property(e => e.SizeName)
                .HasMaxLength(100)
                .HasColumnName("Size_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}