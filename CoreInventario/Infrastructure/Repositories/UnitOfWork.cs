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
        public ISalidaRepository Salida { get; }
        public IOrdenCompraRepository OrdenCompra { get; }
        public IOrdenCompraDetalleRepository OrdenCompraDetalle { get; }
        public IUnidadMedidaRepository UnidadMedida { get; }
        public IParametroRepository Parametro { get; }

        public UnitOfWork(
            ICategoriaProductoRepository categoriaProducto, 
            IProductoRepository producto,
            IProveedorRepository proveedor,
            IClienteRepository cliente,
            IEntradaRepository entrada,
            IUsuarioRepository usuario,
            IRolRepository rol,
            ISalidaRepository salida,
            IOrdenCompraRepository ordenCompra,
            IOrdenCompraDetalleRepository ordenCompraDetalle,
            IUnidadMedidaRepository unidadMedida,
            IParametroRepository parametro)
        {
            CategoriaProducto = categoriaProducto;
            Producto = producto;
            Proveedor = proveedor;
            Cliente = cliente;
            Entrada = entrada;
            Usuario = usuario;
            Rol = rol;
            Salida = salida;
            OrdenCompra = ordenCompra;
            OrdenCompraDetalle = ordenCompraDetalle;
            UnidadMedida = unidadMedida;
            Parametro = parametro;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
