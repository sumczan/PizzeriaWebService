using Microsoft.EntityFrameworkCore;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PizzeriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddTransient<PizzeriaDbContext>();

builder.Services.AddTransient<IBeverageRepository, BeverageRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IClientBlacklistRepository, ClientBlacklistRepository>();
builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();
builder.Services.AddTransient<IIngredientTypeRepository, IngredientTypeRepository>();
builder.Services.AddTransient<IOrderAddressRepository, OrderAddressRepository>();
builder.Services.AddTransient<IOrderBeverageRepository, OrderBeverageRepository>();
builder.Services.AddTransient<IOrderPizzaIngredientChangeRepository, OrderPizzaIngredientChangeRepository>();
builder.Services.AddTransient<IOrderPizzaIngredientExtraRepository,OrderPizzaIngredientExtraRepository>();
builder.Services.AddTransient<IOrderPizzaRepository, OrderPizzaRepository>();
builder.Services.AddTransient<IOrderPlacedRepository, OrderPlacedRepository>();
builder.Services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddTransient<IOrderTypeRepository, OrderTypeRepository>();
builder.Services.AddTransient<IPizzaIngredientRepository, PizzaIngredientRepository>();
builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
builder.Services.AddTransient<IPizzaSizeRepository, PizzaSizeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
