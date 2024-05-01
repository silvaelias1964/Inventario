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
    public class EntradaRepository : IEntradaRepository, IDisposable
    {
        private ApplicationDbContext context;

        public EntradaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<EntradaDTO> GetAll()
        {
            //SELECT E.Id, E.PrdId, P.PrdCodigo, P.PrdNombre, E.EntPrecioUnidad, E.EntStock, E.EntFecha, E.EntEstatus
            //FROM Entrada E INNER JOIN Producto P ON P.Id = E.PrdId


            var lista = context.Entrada.Select(c => new EntradaDTO
            {
                Id = c.Id,
                ProductoId = (int)c.ProductoId,
                PrdCodigo = c.Producto.PrdCodigo,
                Nombre = c.Producto.PrdNombre,
                Precio = c.EntPrecioUnidad,
                Cantidad = c.EntStock,
                Fecha = c.EntFecha.ToString(),
                Estatus = c.EntEstatus

            }).ToList();

            return lista;
        }


        public Entrada GetByID(int id)
        {
            return context.Entrada.FromSqlRaw($"SELECT * FROM Entrada WHERE Id = {id}")
                .FirstOrDefault();
        }

        public async Task Add(Entrada entrada)
        {
            context.Entrada.Add(entrada);
        }

        public async Task Delete(int id)
        {
            Entrada entrada = context.Entrada.Find(id);
            context.Entrada.Remove(entrada);
        }

        public async Task Update(Entrada entrada)
        {
            context.Entry(entrada).State = EntityState.Modified;
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

        ///// <summary>
        ///// Extraer el titulo del enum
        ///// </summary>
        ///// <param name="estatId"></param>
        ///// <returns></returns>
        //static string DescribEstatus(Enum estatId)
        //{
        //    return EnumHelper.GetDescriptionFromEnumValue(estatId);
        //}

    }

}

