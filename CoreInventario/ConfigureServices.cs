using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Helpers;
using CoreInventario.Transversal.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario
{
    public static class ConfigureServices
    {


        public static IServiceCollection AddCoreInventarioServices(
            this IServiceCollection services, 
            IConfiguration configuration, 
            string _connectionDataBase,
            string _pathAvatar,
            string _pathProductos,
            string _pathFactor1,
            string _pathFactor2,
            string _pathArchivos,
            string _pathSalidas
            ) 
        {
            services.AddSingleton<IDataBaseConfiguration>(new DataBaseConfiguration { Connection = _connectionDataBase });
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ILibreriaService, LibreriaService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEntradaService, EntradaService>();
            services.AddScoped<ISalidaService, SalidaService>();
            services.AddScoped<IOrdenCompraService, OrdenCompraService>();
            services.AddScoped<IConfiguracionService, ConfiguracionService>();
            services.AddTransient<SesionService>();
            services.AddSingleton<IPathConfiguration>(new PathConfiguration
            {  PathAvatar  = _pathAvatar,
               PathProductos = _pathProductos,
               PathFactor1 = _pathFactor1,
               PathFactor2 = _pathFactor2,
               PathArchivos= _pathArchivos,
               PathSalidas = _pathSalidas
            });
            services.AddSingleton<PathProvider>();
            services.AddSingleton<FileSanity>();
            services.AddSingleton<UploadFile>();
            services.AddSingleton<DeleteFile>();
            return services;
        }
    }
}
