using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{
    public interface IProductoService
    {
        Task<IEnumerable> GetAll();

        Task<Producto> GetById(int id);

        Task<string> Add(ProductoModel model);

        Task<string> Edit(ProductoModel model);

        Task<string> Delete(int id);
    }
}
