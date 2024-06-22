using CoreInventario.Domain.Entities;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IOrdenCompraDetalleRepository : IRepositoryBase<OrdenCompraDetalle>
    {
        void Delete(int id);
        void Save();
    }
}