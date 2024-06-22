using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    
    public interface IOrdenCompraRepository : IDisposable
    {

        IEnumerable<OrdenCompraDTO> GetAll();

        OrdenCompra GetByID(int id);

        Task Add(OrdenCompra ordenCompra);

        Task Delete(OrdenCompra ordenCompra);

        Task Update(OrdenCompra ordenCompra);

        void Save();

        IEnumerable<OrdenCompraDetalle> GetByIDDetal(int id);
    }

}
