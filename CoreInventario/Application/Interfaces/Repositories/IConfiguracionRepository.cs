using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IConfiguracionRepository : IDisposable
    {
        Configuracion GetByID(int id);

        Task Add(Configuracion configuracion);

        Task Update(Configuracion configuracion);

        void Save();
    }
}
