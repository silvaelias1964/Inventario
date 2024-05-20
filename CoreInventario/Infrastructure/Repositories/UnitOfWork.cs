using CoreInventario.Application.Interfaces.Repositories;

namespace CoreInventario.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoriaProductoRepository CategoriaProducto { get; }
        public IProductoRepository Producto { get; }
        public IProveedorRepository Proveedor { get; }
        public IClienteRepository Cliente { get; }
        public IEntradaRepository Entrada { get; }
        public IUsuarioRepository Usuario { get; }
        public IRolRepository Rol { get; }

        public UnitOfWork(
            ICategoriaProductoRepository categoriaProducto, 
            IProductoRepository producto, 
            IProveedorRepository proveedor, 
            IClienteRepository cliente,
            IEntradaRepository entrada,
            IUsuarioRepository usuario,
            IRolRepository rol)
        {
            CategoriaProducto = categoriaProducto;
            Producto = producto;
            Proveedor = proveedor;
            Cliente = cliente;
            Entrada = entrada;
            Usuario = usuario;
            Rol = rol;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
