using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{    

    public interface IClienteRepository : IDisposable 
    {
        IEnumerable<ClienteDTO> GetAll();

        Cliente GetByID(int id);

        Task Add(Cliente cliente);

        Task Delete(int id);

        Task Update(Cliente cliente);

        void Save();

    }

}
