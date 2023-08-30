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
    public class ClienteRepository : IClienteRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ClienteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var lista = context.Cliente.Select(c => new ClienteDTO
            {
                Id = c.Id,
                CliCodigo = c.CliCodigo,
                CliRazonSocial = c.CliRazonSocial,
                CliContacto = c.CliContacto,
                CliEstatus = c.CliEstatus,
                clienteEstatus = (ClienteEstatusEnum)c.CliEstatus

            }).ToList();

            return lista;
        }

        public Cliente GetByID(int id)
        {
            return context.Cliente.FromSqlRaw($"SELECT * FROM Cliente WHERE Id = {id}")
                .FirstOrDefault();
        }

        public async Task Add(Cliente cliente)
        {
            context.Cliente.Add(cliente);
        }
            
        public async Task Delete(int id)
        {
            Cliente cliente = context.Cliente.Find(id);
            context.Cliente.Remove(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            context.Entry(cliente).State = EntityState.Modified;
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
