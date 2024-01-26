using BrozdziakJankowski.BeerCatalog.BL;
using BrozdziakJankowski.BeerCatalog.DAO;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BeerCatalogContext>();

builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
