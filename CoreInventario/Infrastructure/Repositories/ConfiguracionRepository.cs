using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using CoreInventario.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Infrastructure.Repositories
{   

    public class ConfiguracionRepository : IConfiguracionRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ConfiguracionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public Configuracion GetByID(int id)
        {
            return context.Configuracion.Find(id);
        }

        public Configuracion GetAll()
        {
            return context.Configuracion.FromSqlRaw($"SELECT * FROM Configuracion")
                .FirstOrDefault();
            
        }

        public async Task Add(Configuracion configuracion)
        {
            context.Configuracion.Add(configuracion);
        }


        public async Task Update(Configuracion configuracion)
        {
            context.Entry(configuracion).State = EntityState.Modified;
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
