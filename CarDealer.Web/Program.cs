using CarDealer.Application.Services;
using CarDealer.Core.Core.Models;
using CarDealer.Core.Interfaces;
using CarDealer.Infrastructure;
using CarDealer.Infrastructure.Repositories;
using CarDealer.Web.Models;
using CarDealer.Web.Models.Dashboard.Interfaces;
using CarDealer.Web.Models.Dashboard.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Car>, CarRepository>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<ICarServ, CarServ>();
builder.Services.AddScoped<IInquiryServ, InquiryServ>();
// Service ended
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
