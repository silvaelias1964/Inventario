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
    public class ProductoRepository : IProductoRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ProductoRepository(ApplicationDbContext context)            
        {
            this.context = context;
        }

        public IEnumerable<ProductoDTO> GetAll()
        {
            var lista = context.Producto.Select(c => new ProductoDTO
            {
                Id = c.Id,
                PrdCodigo = c.PrdCodigo,
                PrdNombre = c.PrdNombre,
                CatDescripcion = c.CategoriaProducto.CatDescripcion,
                PrvNombreCompania = c.Proveedor.PrvNombreCompania,
                PrdEstatus= c.PrdEstatus,
                productoEstatus = (ProductoEstatusEnum)c.PrdEstatus
            }).ToList();

            return lista; 
        }

        public Producto GetByID(int id)
        {            
            return context.Producto.FromSqlRaw($"SELECT * FROM Producto WHERE Id = {id}")
                .FirstOrDefault();
        }

        public async Task Add(Producto producto)
        {
            context.Producto.Add(producto);
        }

        public async Task Delete(int id)
        {
            Producto producto = context.Producto.Find(id);
            context.Producto.Remove(producto);
        }

        public async Task Update(Producto producto)
        {
            context.Entry(producto).State = EntityState.Modified;
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
