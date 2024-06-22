using CoreInventario.Application.DTOS;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IProveedorRepository : IDisposable //IRepositoryBase<Proveedor>
    {
        IEnumerable<ProveedorDTO> GetAll();

        Proveedor GetByID(int id);

        IEnumerable<ProveedorModel> GetAllByStatus(int status);

        Task Add(Proveedor proveedor);

        Task Delete(int id);

        Task Update(Proveedor proveedor);

        void Save();

    }
}
