using CoreInventario.Application.Models;
using System.Collections;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{
    public interface IOrdenCompraService
    {
        Task<IEnumerable> GetAll();
        Task<OrdenCompraModel> GetById(int id);
        Task<string> Add(OrdenCompraModel model);
        Task<string> Edit(OrdenCompraModel model);
        Task<string> Delete(int id);                
    }
}