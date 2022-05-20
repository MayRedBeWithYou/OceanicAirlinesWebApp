using OceanicAirlinesWebApp.Algorithms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OceanicAirlinesWebApp.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OceanicAirlinesWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OceanicDBContext") ?? throw new InvalidOperationException("Connection string 'OceanicAirlinesWebAppContext' not found.")));

// Add services to the container.
builder.Services.AddRazorPages();
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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
