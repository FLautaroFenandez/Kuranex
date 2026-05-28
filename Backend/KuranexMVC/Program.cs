using Microsoft.EntityFrameworkCore;
using KuranexMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor (ANTES del Build)
builder.Services.AddControllersWithViews();

// Agregamos el contexto de base de datos usando SQL Server
builder.Services.AddDbContext<KuranexDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Construir la app (SÓLO UNA VEZ)
var app = builder.Build();

// 3. Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();