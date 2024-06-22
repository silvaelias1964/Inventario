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
    public class SalidaRepository : ISalidaRepository, IDisposable
    {
        private ApplicationDbContext context;

        public SalidaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<SalidaDTO> GetAll()
        {
            //SELECT E.Id, E.PrdId, P.PrdCodigo, P.PrdNombre, E.EntPrecioUnidad, E.EntStock, E.EntFecha, E.EntEstatus
            //FROM Salida E INNER JOIN Producto P ON P.Id = E.PrdId


            var lista = context.Salida.Select(c => new SalidaDTO
            {
                Id = c.Id,
                ProductoId = (int)c.ProductoId,
                PrdCodigo = c.Producto.PrdCodigo,
                Nombre = c.Producto.PrdNombre,
                //Precio = c.SalPrecioUnidad,
                Cantidad = c.SalStock,
                Fecha = c.SalFecha.Value.ToString("dd/MM/yyyy"),
                Estatus = c.SalEstatus,
                salidaEstatus = (EntSalEstatusEnum)c.SalEstatus

            }).ToList();

            return lista;
        }


        public Salida GetByID(int id)
        {
            return context.Salida.FromSqlRaw($"SELECT * FROM Salida WHERE Id = {id}")
                .FirstOrDefault();
        }

        public async Task Add(Salida salida)
        {
            context.Salida.Add(salida);
        }

        public async Task Delete(int id)
        {
            Salida salida = context.Salida.Find(id);
            context.Salida.Remove(salida);
        }

        public async Task Update(Salida salida)
        {
            context.Entry(salida).State = EntityState.Modified;
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


    }

}


