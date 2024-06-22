using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using CoreInventario.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoreInventario.Infrastructure.Repositories.OrdenCompraRepository;

namespace CoreInventario.Infrastructure.Repositories
{
    public class OrdenCompraRepository : IOrdenCompraRepository, IDisposable
    {
        private ApplicationDbContext context;

        public OrdenCompraRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<OrdenCompraDTO> GetAll()
        {
            //SELECT E.Id, E.PrdId, P.PrdCodigo, P.PrdNombre, E.EntPrecioUnidad, E.EntStock, E.EntFecha, E.EntEstatus
            //FROM Entrada E INNER JOIN Producto P ON P.Id = E.PrdId

            var lista = context.OrdenCompra.Select(c => new OrdenCompraDTO
            {
                Id = c.Id,
                ProveedorId = c.ProveedorId,                
                FechaEmision = c.OccFechaEmision.Value.ToString("dd/MM/yyyy"),
                FechaOrden = c.OccFechaOrden.Value.ToString("dd/MM/yyyy"),
                OrdenCompraNro = c.OccNroOrden,
                ProveedorNombre = c.Proveedor.PrvNombreCompania,
                Estatus = (OdcEstatusEnum)c.OccEstatus,
                EstatusId = c.OccEstatus

            }).ToList();

            return lista;
        }


        public OrdenCompra GetByID(int id)
        {
            return context.OrdenCompra.FromSqlRaw($"SELECT * FROM OrdenCompra WHERE Id = {id}")
                .FirstOrDefault();
        }

        public async Task Add(OrdenCompra ordenCompra)
        {
            context.OrdenCompra.Add(ordenCompra);
        }

        public async Task Delete(OrdenCompra ordenCompra)
        {            
            context.OrdenCompra.Remove(ordenCompra);
        }

        public async Task Update(OrdenCompra ordenCompra)
        {
            context.Entry(ordenCompra).State = EntityState.Modified;
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
        /// Busqueda del detalle de la OC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<OrdenCompraDetalle> GetByIDDetal(int id)
        {
            var lista = context.OrdenCompraDetalle.Select(c => new OrdenCompraDetalle
            {
                Id = c.Id,
                ProductoId = c.ProductoId,
                OcdCantidad = c.OcdCantidad,
                UnidadMedidaId = c.UnidadMedidaId,
                Producto = c.Producto,
                OrdenCompra = c.OrdenCompra,
                UnidadMedida = c.UnidadMedida

            }).ToList().Where(c => c.OrdenCompra.Id.Equals(id));
            return lista;
        }



    }
}
