using CoreInventario.Application.DTOS;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        IEnumerable<UsuarioDTO> GetAll();

        Usuario GetUsuario(string correo, string clave);

        Usuario GetByID(int id);

        Task Add(Usuario usuario);

        Task Delete(int id);

        Task Update(Usuario usuario);

        void Save();
    }
}
