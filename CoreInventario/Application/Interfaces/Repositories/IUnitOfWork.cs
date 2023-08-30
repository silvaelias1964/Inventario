using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductoRepository Producto { get; }
        ICategoriaProductoRepository CategoriaProducto { get; }
        IProveedorRepository Proveedor { get; }
        IClienteRepository Cliente { get; }
    }
}
