using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IProductoRepository : IDisposable
    {

        IEnumerable<ProductoDTO> GetAll();

        Producto GetByID(int id);

        Task Add(Producto producto);

        Task Delete(int id);

        Task Update(Producto producto);

        void Save();
    }
}
