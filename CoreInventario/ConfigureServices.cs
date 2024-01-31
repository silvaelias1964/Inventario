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
        public static IServiceCollection AddCoreInventarioServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ILibreriaService, LibreriaService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddTransient<SesionService>();
            return services;
        }
    }
}
