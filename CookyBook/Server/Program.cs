using AutoMapper.EquivalencyExpression;
using CookyBook.Server.AutoMapperProfiles;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Impl;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CookBookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CookBookConnection")));

builder.Services.AddTransient<ICookBookRepository<Recipe>, CookBookRepository<Recipe>>();
builder.Services.AddTransient<ICookBookRepository<Nutrient>, CookBookRepository<Nutrient>>();
builder.Services.AddTransient<ICookBookRepository<Category>, CookBookRepository<Category>>();
builder.Services.AddTransient<ICookBookRepository<Ingredient>, CookBookRepository<Ingredient>>();

AddAutoMapperProfiles(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


void AddAutoMapperProfiles(IServiceCollection services)
{
    services.AddAutoMapper(automapper => automapper.AddCollectionMappers());
    services.AddAutoMapper(typeof(RecipeProfile));
    services.AddAutoMapper(typeof(IngredientProfile));
    services.AddAutoMapper(typeof(CategoryProfile));
    services.AddAutoMapper(typeof(NutrientProfile));
}