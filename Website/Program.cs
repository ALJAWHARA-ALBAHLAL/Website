using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Website.Models;
using Website.Models.Repositories;
using Website.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

//Dependncies
//services.AddSingleton<IShopRepositpry<Customer>, CustomerRepository>(); //Concret type and interface
//services.AddSingleton<IShopRepositpry<Order>, OrderRepository>(); //Concret type and int

builder.Services.AddScoped<IShopRepositpry<Customer>, CustomerDbRepository>(); //Concret type and interface
builder.Services.AddScoped<IShopRepositpry<Order>, OrderDbRepository>(); //Concret type and int


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebsiteDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb"))); //Connect


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
