using AutoMapper;
using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Transversal.Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoreInventario.Transversal.Logins;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CoreInventario.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAppLogger<ClienteService> appLogger;

        // Constructor
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<ClienteService> appLogger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.appLogger= appLogger;
        }

        /// <summary>
        /// Traer todos los clientes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> GetAll()
        {
            var entities = unitOfWork.Cliente.GetAll();
            return (IEnumerable)entities;
        }

        /// <summary>
        /// Traer datos de un cliente por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cliente> GetById(int id)
        {
            Cliente entities = unitOfWork.Cliente.GetByID(id);
            return entities;
        }

        /// <summary>
        /// Agregar cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(ClienteModel model)
        {
            try
            {

                var entity = mapper.Map<Cliente>(model); //Mapping con mapper                
                await unitOfWork.Cliente.Add(entity);
                unitOfWork.Cliente.Save();
                entity.CreadoPor = model.IdUsuarioSesion + " - " + model.UsuarioSesion;
                appLogger.LogInformation($"[{entity.CreadoPor}], Creación de Cliente: {entity.Id.ToString()}", entity.CreadoPor);                
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                appLogger.LogError("Error: " + error + " - " + msg);
                return "Error: " + error + " - " + msg;
            }
        }

        /// <summary>
        /// Editar cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Edit(ClienteModel model)
        {
            try
            {                

                var entity = mapper.Map<Cliente>(model); //Mapping con mapper                               
                await unitOfWork.Cliente.Update(entity);
                unitOfWork.Cliente.Save();
                entity.ActualizadoPor = model.IdUsuarioSesion + " - " + model.UsuarioSesion;
                appLogger.LogInformation($"[{entity.ActualizadoPor}],Modificación de Cliente: {entity.Id.ToString()}", entity.ActualizadoPor);
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                appLogger.LogError("Error: " + error + " - " + msg);
                return "Error: " + error + " - " + msg;
            }

        }


        /// <summary>
        /// Borrar un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id, UsuarioSesionDTO usuarioLog)
        {
            try
            {                
                await unitOfWork.Cliente.Delete(id);
                unitOfWork.Cliente.Save();
                appLogger.LogInformation($"[{usuarioLog.IdUsuario + " - " + usuarioLog.Usuario}],Eliminación de Cliente: {id.ToString()}");
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                appLogger.LogError("Error: " + error + " - " + msg);
                return "Error: " + error + " - " + msg;
            }
        }
    }
}
