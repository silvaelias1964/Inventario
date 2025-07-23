using AutoMapper;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Helpers;
using CoreInventario.Infrastructure.Repositories;
using CoreInventario.Transversal.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreInventario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDataBaseConfiguration connection;
        private readonly ILibreriaService libreriaService;
        private readonly IPathConfiguration pathConfiguration;
        public UploadFile uploadFile;
        public DeleteFile deleteFile;
        public PathProvider pathProvider;


        public UsuarioService(
            IUsuarioRepository usuarioRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IDataBaseConfiguration connection, 
            ILibreriaService libreriaService,
            IPathConfiguration pathConfiguration,
            UploadFile uploadFile,
            DeleteFile deleteFile,
            PathProvider pathProvider)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.connection = connection;
            this.libreriaService = libreriaService;
            this.pathConfiguration = pathConfiguration;
            this.uploadFile = uploadFile;
            this.deleteFile = deleteFile;
            this.pathProvider = pathProvider;
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
                modelo.Foto = pathConfiguration.PathAvatar + "defaultUser.png";   //"/avatar/defaultUser.png";

            await usuarioRepository.Add(modelo);
            usuarioRepository.Save();
            return modelo;
        }

        /// <summary>
        /// Traer datos de un usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Usuario> GetById(int id)
        {
            Usuario entities = unitOfWork.Usuario.GetByID(id);

            //entities.Foto = this.pathProvider.MapPath(entities.Foto, pathConfiguration.PathAvatar);  //pathConfiguration.PathAvatar + entities.Foto;
            entities.Foto = "/"+pathConfiguration.PathAvatar+ "/" + entities.Foto;
            return entities;
        }



        /// <summary>
        /// Agregar usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(UsuarioModel model)
        {
            try
            {
                string imagenSel = "";
                if (model.imagen != null)
                {
                    await this.uploadFile.SubirFichero(model.imagen, pathConfiguration.PathAvatar);
                    if (model.imagen.FileName != null)
                    {
                        imagenSel = model.imagen.FileName;
                    }
                }
                else
                {
                    if (model.IsChangeImg == 0)
                    {
                        imagenSel = model.Foto;
                    }
                }
                if (model.IsConfirmPass == 1)  // Confirmar actualización incluyendo contraseña
                {
                    Usuario entity = new Usuario
                    {                     
                        NombreUsuario = model.NombreUsuario,
                        Correo = model.Correo,
                        Clave = libreriaService.EncriptarClave(model.Clave),
                        Foto = imagenSel,
                        IsNotificacion = model.IsNotificacion,
                        RolId = model.RolId
                    };
                    await unitOfWork.Usuario.Add(entity);
                }
                else
                {
                    Usuario entity = new Usuario
                    {                        
                        NombreUsuario = model.NombreUsuario,
                        Correo = model.Correo,
                        Clave = model.Clave,
                        Foto = imagenSel,
                        IsNotificacion = model.IsNotificacion,
                        RolId = model.RolId
                    };
                    await unitOfWork.Usuario.Add(entity);
                }

                unitOfWork.Usuario.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }
        }

        /// <summary>
        /// Editar usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Edit(UsuarioModel model)
        {
            try
            {
                string imagenSel = "";
                if (model.imagen != null)
                {
                    await this.uploadFile.SubirFichero(model.imagen, pathConfiguration.PathAvatar);
                    if (model.imagen.FileName != null)
                    {
                        imagenSel = model.imagen.FileName;
                    }
                }
                else 
                { 
                    if(model.IsChangeImg==0) 
                    {
                        imagenSel = model.Foto;
                    }
                }

                if (model.IsConfirmPass == 1)  // Confirmar actualización incluyendo contraseña
                {
                    

                    Usuario entity = new Usuario
                    {
                        Id = model.Id,
                        NombreUsuario = model.NombreUsuario,
                        Correo = model.Correo,
                        Clave =  libreriaService.EncriptarClave(model.Clave),
                        Foto = imagenSel,
                        IsNotificacion = model.IsNotificacion,
                        RolId = model.RolId
                    };
                    await unitOfWork.Usuario.Update(entity);
                }
                else
                {
                    Usuario entity = new Usuario
                    {
                        Id = model.Id,
                        NombreUsuario = model.NombreUsuario,
                        Correo = model.Correo,
                        Clave = model.Clave,
                        Foto = imagenSel,
                        IsNotificacion = model.IsNotificacion,
                        RolId = model.RolId
                    };
                    await unitOfWork.Usuario.Update(entity);
                }
                //var entity = mapper.Map<Usuario>(model); //Mapping con mapper               
                unitOfWork.Usuario.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }

        }


        /// <summary>
        /// Borrar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id, string foto)
        {
            try
            {
                await unitOfWork.Usuario.Delete(id);
                unitOfWork.Usuario.Save();

                this.deleteFile.EliminarFichero(foto, pathConfiguration.PathAvatar);

                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }
        }

        /// <summary>
        /// Chequear la modificación del password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentPass"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>        
        public async Task<ResultProcess> CheckPass(int id, string currentPass, string newPass)
        {
            string result = "";
            ResultProcess response = new ResultProcess();
            try
            {
                using (SqlConnection sql = new SqlConnection(connection.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_PasswordCheck", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new SqlParameter("@p_Id", Id));
                        //cmd.Parameters.Add(new SqlParameter("@p_Modo", "E"));
                        //cmd.Parameters.Add(new SqlParameter("@usuario", "Admin"));  // Debe cambiar

                        cmd.Parameters.AddWithValue("@p_Id", id);
                        cmd.Parameters.AddWithValue("@p_Password", currentPass);
                        cmd.Parameters.AddWithValue("@p_PasswordNew", newPass);
                        cmd.Parameters.Add("@o_Error", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        sql.Open();
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            // true
                        }
                        result = cmd.Parameters["@o_Error"].Value.ToString();
                    }
                }

                //var response = new
                //{
                //    respuesta = result
                //};
                //return Json(response);

                response.MsgProc = result;
                response.Id = 0;
                return response;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                response.MsgProc = "Error: " + error + " - " + msg;
                response.Id = 1;
                return response;
            }
        }

        //public async Task<string> CopyImgTemp(IFormFile name) 
        //{
        //    await this.uploadFile.SubirFichero(name, pathConfiguration.PathAvatar);
        //    return "Ok";
        //}


    }
}
