using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzeriaWebService.Core.AutoMapperProfiles;
using PizzeriaWebService.Core.EfModels;
using PizzeriaWebService.Core.Interfaces.Repositories;
using PizzeriaWebService.Core.Interfaces.Services;
using PizzeriaWebService.Repository;
using PizzeriaWebService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new BeverageProfile());
    mc.AddProfile(new CityProfile());
    mc.AddProfile(new ClientBlacklistProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

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

builder.Services.AddTransient<IBeverageService, BeverageService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IClientBlacklistService, ClientBlacklistService>();
builder.Services.AddTransient<IIngredientService, IngredientService>();
builder.Services.AddTransient<IIngredientTypeService, IngredientTypeService>();
builder.Services.AddTransient<IOrderAddressService, OrderAddressService>();
builder.Services.AddTransient<IOrderBeverageService, OrderBeverageService>();
builder.Services.AddTransient<IOrderPizzaIngredientChangeService, OrderPizzaIngredientChangeService>();
builder.Services.AddTransient<IOrderPizzaIngredientExtraService, OrderPizzaIngredientExtraService>();
builder.Services.AddTransient<IOrderPizzaService, OrderPizzaService>();
builder.Services.AddTransient<IOrderPlacedService, OrderPlacedService>();
builder.Services.AddTransient<IOrderStatusService, OrderStatusService>();
builder.Services.AddTransient<IOrderTypeService, OrderTypeService>();
builder.Services.AddTransient<IPizzaIngredientService, PizzaIngredientService>();
builder.Services.AddTransient<IPizzaService, PizzaService>();
builder.Services.AddTransient<IPizzaSizeService, PizzaSizeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/error");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
