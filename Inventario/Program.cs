using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoMapper;
using CoreInventario.Infrastructure.Contexts;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Services;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Infrastructure.Repositories;
using CoreInventario.Infrastructure.Interceptors;
using CoreInventario;
using CoreInventario.Transversal.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var avatarString = builder.Configuration.GetSection("Archivos:Avatar") ?? throw new InvalidOperationException("Path string 'Avatar' not found.");
var productoString = builder.Configuration.GetSection("Archivos:Productos") ?? throw new InvalidOperationException("Path string 'Productos' not found.");
var pathFactor1 = builder.Configuration.GetSection("Url:FactorDolar1") ?? throw new InvalidOperationException("Path string 'FactorDolar1' not found.");
var pathFactor2 = builder.Configuration.GetSection("Url:FactorDolar2") ?? throw new InvalidOperationException("Path string 'FactorDolar2' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(                    
                connectionString, b => b.MigrationsAssembly("CoreInventario.Migration")));  //connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));   

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Security
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Inicio/IniciarSesion";
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
               });

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});


// builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IDataBaseConfiguration>(new DataBaseConfiguration { Connection = connectionString });
builder.Services.AddCoreInventarioServices(builder.Configuration, connectionString, avatarString.Value.ToString(), productoString.Value.ToString(), pathFactor1.Value.ToString(), pathFactor2.Value.ToString());   // Aqui los servicios de CoreInventario
// Repositorios
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<ICategoriaProductoRepository, CategoriaProductoRepository>();
builder.Services.AddTransient<IProveedorRepository, ProveedorRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IEntradaRepository, EntradaRepository>();
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<ISalidaRepository, SalidaRepository>();
builder.Services.AddTransient<IUnidadMedidaRepository, UnidadMedidaRepository>();
builder.Services.AddTransient<IOrdenCompraRepository, OrdenCompraRepository>();
builder.Services.AddTransient<IOrdenCompraDetalleRepository, OrdenCompraDetalleRepository>();
builder.Services.AddScoped<IParametroRepository, ParametroRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



#region Automapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ConfigureAutoMapper());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(Startup).Assembly);

#endregion

// Sesiones
builder.Services.AddResponseCaching();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())   // IsProduction()
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");
app.MapRazorPages();

app.Run();
