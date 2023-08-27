using CoreInventario.Application.Interfaces.Repositories;

namespace CoreInventario.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoriaProductoRepository CategoriaProducto { get; }
        public IProductoRepository Producto { get; }
        public IProveedorRepository Proveedor { get; }
        public IClienteRepository Cliente { get; }

        public UnitOfWork(
            ICategoriaProductoRepository categoriaProducto, 
            IProductoRepository producto, 
            IProveedorRepository proveedor, 
            IClienteRepository cliente)
        {
            CategoriaProducto = categoriaProducto;
            Producto = producto;
            Proveedor = proveedor;
            Cliente = cliente;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
