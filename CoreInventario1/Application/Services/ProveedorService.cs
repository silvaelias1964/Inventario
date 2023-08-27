using AutoMapper;
using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    /// <summary>
    /// Proveedores
    /// </summary>
    public class ProveedorService : IProveedorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        // Constructor
        public ProveedorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Traer todos los proveedores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> GetAll()
        {
            var entities = unitOfWork.Proveedor.GetAll();
            return (IEnumerable)entities;
        }

        /// <summary>
        /// Traer datos de un proveedor por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Proveedor> GetById(int id)
        {
            Proveedor entities = unitOfWork.Proveedor.GetByID(id);
            return entities;
        }

        /// <summary>
        /// Agregar proveedor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(ProveedorModel model)
        {
            try
            {

                var entity = mapper.Map<Proveedor>(model); //Mapping con mapper
                await unitOfWork.Proveedor.Add(entity);
                unitOfWork.Proveedor.Save();
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
        /// Editar proveedor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Edit(ProveedorModel model)
        {
            try
            {
                var entity = mapper.Map<Proveedor>(model); //Mapping con mapper               
                
                await unitOfWork.Proveedor.Update(entity);
                unitOfWork.Proveedor.Save();
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
        /// Borrar un proveedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id)
        {
            try
            {
                await unitOfWork.Proveedor.Delete(id);
                unitOfWork.Proveedor.Save();

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
