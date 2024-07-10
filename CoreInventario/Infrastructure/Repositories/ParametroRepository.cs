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
    public class ParametroRepository : IParametroRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ParametroRepository(ApplicationDbContext context)            
        {
            this.context = context;
        }

        /// <summary>
        /// Buscar valor de parametro por Nombre
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public Parametro GetByNombre(string valor)
        {
            return context.Parametros.FromSqlRaw($"SELECT * FROM Parametros WHERE Upper(PrmNombre) = Upper('{valor}')")
                .FirstOrDefault();
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


