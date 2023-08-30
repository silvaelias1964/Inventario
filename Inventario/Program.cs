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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(                    
                connectionString, b => b.MigrationsAssembly("CoreInventario.Infrastructure.Migration")));  //connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));   

builder.Services.AddSingleton<IDataBaseConfiguration>(new DataBaseConfiguration { Connection = connectionString });


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//               .AddCookie(options =>
//               {
//                   options.LoginPath = "/Inicio/IniciarSesion";
//                   options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//               });

builder.Services.AddControllersWithViews();
builder.Services.AddCoreInventarioServices(builder.Configuration);   // Aqui los servicios de CoreInventario
// Repositorios
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<ICategoriaProductoRepository, CategoriaProductoRepository>();
builder.Services.AddTransient<IProveedorRepository, ProveedorRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
