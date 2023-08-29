using AutoMapper;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        // Constructor
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Traer todos los clientes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> GetAll()
        {
            var entities = unitOfWork.Proveedor.GetAll();
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
        /// Borrar un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id)
        {
            try
            {
                await unitOfWork.Cliente.Delete(id);
                unitOfWork.Cliente.Save();

                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }
        }
    }
}
