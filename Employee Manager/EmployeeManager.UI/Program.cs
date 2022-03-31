using EmployeeManager.Business.Interfaces;
using EmployeeManager.Business.Models;
using EmployeeManager.Business.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

var employeeSettings = new Settings();

// Dependency Injection Container
builder.Configuration.Bind("EmployeeSettings", employeeSettings);
builder.Services.AddSingleton<IEmployeeServices, EmployeeServices>();
builder.Services.AddSingleton<ISettings>(employeeSettings);
builder.Services.AddSingleton<IWorkForce, WorkForce>();

// Add services to the container.
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
