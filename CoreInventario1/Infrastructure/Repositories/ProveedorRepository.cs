using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using CoreInventario.Domain.Helpers;
using CoreInventario.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ProveedorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProveedorDTO> GetAll()
        {
            var lista = context.Proveedor.Select(c => new ProveedorDTO
            {
                Id = c.Id,
                PrvCodigo = c.PrvCodigo,
                PrvNombreCompania = c.PrvNombreCompania,
                PrvContacto = c.PrvContacto,
                PrvEstatus = c.PrvEstatus,
                proveedorEstatus = (ProveedorEstatusEnum)c.PrvEstatus

            }).ToList();

            return lista;
        }

        public Proveedor GetByID(int id)
        {
            return context.Proveedor.FromSqlRaw($"SELECT * FROM Proveedor WHERE Id = {id}")
                .FirstOrDefault();
        }

        public async Task Add(Proveedor proveedor)
        {
            context.Proveedor.Add(proveedor);
        }

        public async Task Delete(int id)
        {
            Proveedor proveedor = context.Proveedor.Find(id);
            context.Proveedor.Remove(proveedor);
        }

        public async Task Update(Proveedor proveedor)
        {
            context.Entry(proveedor).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Extraer el titulo del enum
        /// </summary>
        /// <param name="estatId"></param>
        /// <returns></returns>
        static string DescribEstatus(Enum estatId)
        {
            return EnumHelper.GetDescriptionFromEnumValue(estatId);
        }
    }
}
