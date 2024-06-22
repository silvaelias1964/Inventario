using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{

    public interface ISalidaRepository : IDisposable
    {

        IEnumerable<SalidaDTO> GetAll();

        Salida GetByID(int id);

        Task Add(Salida salida);

        Task Delete(int id);

        Task Update(Salida salida);

        void Save();
    }
}
