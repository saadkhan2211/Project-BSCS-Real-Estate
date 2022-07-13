using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_BSCS.Data;
using Project_BSCS.Models;
using Project_BSCS.Repository;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Sign Up Data Base
builder.Services.AddDbContext<RegDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LoginConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<RegDbContext>();

// Property Data Base
builder.Services.AddDbContext<PropertyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LoginConnection")));

// Add PropertyRepository
builder.Services.AddScoped<PropertyRepository, PropertyRepository>();

builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredUniqueChars = 0;
});

// Razor WebPages
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
