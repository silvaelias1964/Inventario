using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Services;
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


        public static IServiceCollection AddCoreInventarioServices(this IServiceCollection services, IConfiguration configuration, string _connectionDataBase) 
        {
            services.AddSingleton<IDataBaseConfiguration>(new DataBaseConfiguration { Connection = _connectionDataBase });
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ILibreriaService, LibreriaService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEntradaService, EntradaService>();
            services.AddTransient<SesionService>();
            return services;
        }
    }
}
