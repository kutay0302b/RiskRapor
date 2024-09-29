using RiskRapor.Data;
using Microsoft.EntityFrameworkCore;
using DinkToPdf.Contracts;
using DinkToPdf;
using OfficeOpenXml;
using Microsoft.Extensions.DependencyInjection;

//using RiskRapor.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabaný baðlantýsý ve DbContext servisini ekleme
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
//builder.Services.AddScoped<IAnlasmalarRepository, AnlasmalarRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
// Varsayýlan rota ayarý (MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
