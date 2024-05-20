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
    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var lista = context.Usuario.Select(c => new UsuarioDTO
            {
                IdUsuario = c.Id,
                NombreUsuario = c.NombreUsuario,
                Correo = c.Correo,
                EstatusUsuario = (int)c.EstatusUsuario,
                usuarioEstatus = (UsuarioEstatusEnum)(ClienteEstatusEnum)c.EstatusUsuario
            }).ToList();

            return lista;
        }

        public Usuario GetUsuario(string correo, string clave)
        {
            Usuario usuario = new Usuario();
            var result = context.Usuario.FirstOrDefault(c => c.Correo == correo && c.Clave == clave);
            if (result != null)
            {
                usuario.Id = result.Id;
                usuario.NombreUsuario = result.NombreUsuario;
                usuario.Correo = result.Correo;
                usuario.Clave = result.Clave;
                usuario.Foto = result.Foto;
            }
            return usuario;
        }

        public Usuario GetByID(int id)
        {
            return context.Usuario.Find(id);
        }

        public async Task Add(Usuario usuario)
        {
            context.Usuario.Add(usuario);
        }

        public async Task Delete(int id)
        {
            Usuario usuario = context.Usuario.Find(id);
            context.Usuario.Remove(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
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
