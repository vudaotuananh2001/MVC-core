using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.Data;
using MVC.Repository;
using MVC.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// connect database
builder.Services.AddDbContext<ApplicationConnection>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Connection"),
        sqlOptions => sqlOptions.CommandTimeout(120)
    ).EnableSensitiveDataLogging() // Enable this only for debugging purposes
);

builder.Services.AddScoped<CategoryRepository>(); // Đăng ký CategoryRepository
builder.Services.AddScoped<CategoryService>();   // Đăng ký CategoryService

builder.Services.AddScoped<ProductRepository>(); // Đăng ký ProductRepository
builder.Services.AddScoped<ProductService>();   // Đăng ký ProductService

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
