using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable> GetAll()
        {
            var entities = usuarioRepository.GetAll();
            return entities;
        }


        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            var result = usuarioRepository.GetUsuario(correo, clave);
            return result;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            if (modelo.Foto == null)
                modelo.Foto="/avatar/defaultUser.png";

            await usuarioRepository.Add(modelo);
            usuarioRepository.Save();
            return modelo;
        }
    }
}
