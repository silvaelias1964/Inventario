using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable> GetAll();
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);       
        Task<Usuario> GetById(int id);
        Task<string> Add(UsuarioModel model);
        Task<string> Edit(UsuarioModel model);
        Task<string> Delete(int id, string foto);
        Task<ResultProcess> CheckPass(int id, string currentPass, string newPass);

        //Task<string> CopyImgTemp(IFormFile name);
    }
}
