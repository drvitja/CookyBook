using AutoMapper.EquivalencyExpression;
using CookyBook.Server.AutoMapperProfiles;
using DataAccess.Repositories;
using DataAccess.Repositories.Impl;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<ICookBookRepository, CookBookRepository>();
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
    services.AddAutoMapper(typeof(NutritionProfile));
}