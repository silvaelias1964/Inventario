using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Infrastructure.Repositories
{
    public class OrdenCompraDetalleRepository : IOrdenCompraDetalleRepository, IDisposable
    {
        private ApplicationDbContext context;
        private readonly IConfiguration configuration;
        
        public OrdenCompraDetalleRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public void Delete(int id)    //  async Task Delete(int id)
        {
         
            using (SqlConnection conect = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarDetalleOC", conect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@mode", 1);

                    conect.Open();
                    cmd.ExecuteNonQuery();
                }
            }
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

        public Task Add(OrdenCompraDetalle obj)
        {
            throw new NotImplementedException();
        }

        public Task<OrdenCompraDetalle> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrdenCompraDetalle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(OrdenCompraDetalle obj)
        {
            throw new NotImplementedException();
        }

        public Task Remove(OrdenCompraDetalle obj)
        {
            throw new NotImplementedException();
        }
    }
}
