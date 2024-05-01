using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{

    public interface IEntradaRepository : IDisposable
    {

        IEnumerable<EntradaDTO> GetAll();

        Entrada GetByID(int id);

        Task Add(Entrada entrada);

        Task Delete(int id);

        Task Update(Entrada entrada);

        void Save();
    }
}
