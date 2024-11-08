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
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        // Constructor
        public ConfiguracionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Traer datos de la configuracion por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Configuracion> GetById(int id)
        {
            Configuracion entities = unitOfWork.Configuracion.GetByID(id);
            return entities;
        }

        /// <summary>
        /// Traer todos los registros, en este caso solo el ultimo
        /// </summary>
        /// <returns></returns>
        public Configuracion GetAll()
        {
            Configuracion entities = new Configuracion();
            entities = unitOfWork.Configuracion.GetAll();
            return entities;
        }



        /// <summary>
        /// Agregar configuracion
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(ConfiguracionModel model)
        {
            try
            {
                var entity = mapper.Map<Configuracion>(model); //Mapping con mapper
                await unitOfWork.Configuracion.Add(entity);
                unitOfWork.Configuracion.Save();
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
        /// Editar configuracion
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Edit(ConfiguracionModel model)
        {

            try
            {
                var entity = mapper.Map<Configuracion>(model); //Mapping con mapper               

                unitOfWork.Configuracion.Update(entity);
                unitOfWork.Configuracion.Save();
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
