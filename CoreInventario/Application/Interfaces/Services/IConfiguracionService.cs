using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{
    public interface IConfiguracionService
    {
        Task<Configuracion> GetById(int id);
        Configuracion GetAll();
        Task<string> Add(ConfiguracionModel model);
        string Edit(ConfiguracionModel model);
    }
}
