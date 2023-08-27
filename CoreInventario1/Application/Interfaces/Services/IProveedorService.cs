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
    public interface IProveedorService
    {
        Task<IEnumerable> GetAll();

        Task<Proveedor> GetById(int id);

        Task<string> Add(ProveedorModel model);

        Task<string> Edit(ProveedorModel model);

        Task<string> Delete(int id);
    }
}
