using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IParametroRepository : IDisposable
    {
        Parametro GetByNombre(string valor);
    }
}
