global using Interdisciplinar2023.Interfaces;
global using Interdisciplinar2023.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Interdisciplinar2023.Repositories;
using Interdisciplinar2023.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IProductsRepository, ProductRepository>();

builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlite(connectionString));

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.Configure<IdentityOptions>(options =>
        { options.User.RequireUniqueEmail = true; });

builder.Services.AddMemoryCache();

builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
// "DefaultConnection": "User Id=postgres;Password=docker;Host=localhost;Port=5432;Database=Interdisciplinar2023;Pooling=true;IncludeErrorDetail=true" 
