using AutoMapper;
using Azure;
using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreInventario.Application.Services
{

    /// <summary>
    /// Salidas al inventario
    /// </summary>
    public class SalidaService : ISalidaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IProductoService productoService;
        private readonly IDataBaseConfiguration connection;

        // Constructor
        public SalidaService(IUnitOfWork unitOfWork, IMapper mapper, IDataBaseConfiguration connection, IProductoService productoService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.connection = connection;
            this.productoService = productoService;
        }

        /// <summary>
        /// Traer todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> GetAll()
        {
            var entities = unitOfWork.Salida.GetAll();
            return (IEnumerable)entities;
        }

        /// <summary>
        /// Traer datos de un producto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Salida> GetById(int id)
        {
            Salida entities = unitOfWork.Salida.GetByID(id);
            return entities;
        }

        /// <summary>
        /// Agregar salidas
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultProcess> Add(SalidaModel model)
        {
            ResultProcess response = new ResultProcess();
            try
            {
                // Mapping sin mapper
                //Producto entity = new Producto
                //{
                //    PrdCodigo = model.PrdCodigo,
                //    PrdNombre = model.PrdNombre,
                //    CatId = model.CatId,
                //    PrvId = model.PrvId,
                //    PrdCantPorUnidad = model.PrdCantPorUnidad,
                //    PrdPrecioUnidad =  model.PrdPrecioUnidad,
                //    PrdStockMinimo = model.PrdStockMinimo,
                //    PrdStock = model.PrdStock,
                //    PrdEstatus = model.PrdEstatus
                //};

                var entity = mapper.Map<Salida>(model); //Mapping con mapper
                entity.ProductoId = entity.ProductoId == 0 ? null : entity.ProductoId;
                await unitOfWork.Salida.Add(entity);
                unitOfWork.Entrada.Save();
                response.Id = entity.Id;  // Id autogenerado 

                string resultEnt = "";
                if (model.ActualizaInv == true)
                {
                    resultEnt = await RestarInventario((int)entity.ProductoId, entity.SalStock, response.Id);
                    if (resultEnt != "Ok")
                    {
                        response.MsgProc = "Ok-No";
                        return response;
                    }
                }
                response.MsgProc = "Ok-Ok";
                return response;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                response.Id = 0;
                response.MsgProc = "Error: " + error + " - " + msg;
                return response;
            }
        }

        public async Task<string> Edit(SalidaModel model)
        {
            try
            {
                // Mapping if data correct
                //Producto entity = new Producto
                //{
                //    PrdCodigo = model.PrdCodigo,
                //    PrdNombre = model.PrdNombre,
                //    CatId = model.CatId,
                //    PrvId = model.PrvId,
                //    PrdCantPorUnidad = model.PrdCantPorUnidad,
                //    PrdPrecioUnidad = model.PrdPrecioUnidad,
                //    PrdStockMinimo = model.PrdStockMinimo,
                //    PrdStock = model.PrdStock,
                //    PrdEstatus = model.PrdEstatus
                //};
                var entity = mapper.Map<Salida>(model); //Mapping con mapper               
                entity.ProductoId = entity.ProductoId == 0 ? null : entity.ProductoId;
                await unitOfWork.Salida.Update(entity);
                unitOfWork.Salida.Save();
                string resultEnt = "";
                resultEnt = await RestarInventario((int)entity.ProductoId, entity.SalStock, entity.Id);
                if (resultEnt != "Ok")
                {
                    return "Ok-No";
                }

                await ActualizaEstatusEntSal(entity.Id);
                return "Ok-Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }

        }


        /// <summary>
        /// Borrar una salida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id)
        {
            try
            {
                await unitOfWork.Salida.Delete(id);
                unitOfWork.Salida.Save();

                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }
        }

        #region private methods

        /// <summary>
        /// Restar productos al inventario
        /// </summary>
        /// <param name="ProductoId"></param>
        /// <param name="EntStock"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        private async Task<string> RestarInventario(int ProductoId, int EntStock, int Id)
        {
            try
            {
                var datos = productoService.GetById(ProductoId);
                if (datos == null)
                {
                    return "Error";
                }
                using (SqlConnection sql = new SqlConnection(connection.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ActInventario", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@p_ProductoId", ProductoId));
                        cmd.Parameters.Add(new SqlParameter("@p_Cantidad", EntStock));
                        cmd.Parameters.Add(new SqlParameter("@p_Modo", "S"));
                        cmd.Parameters.Add(new SqlParameter("@p_Usuario", "Admin"));  // Debe cambiar
                        cmd.Parameters.Add(new SqlParameter("@p_EntSalId", Id));  // Id de la entrada recien generado

                        sql.Open();
                        cmd.ExecuteReader();
                    }
                }

                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }
        }


        private async Task<string> ActualizaEstatusEntSal(int Id)
        {

            using (SqlConnection sql = new SqlConnection(connection.Connection))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActEstatusEntSal", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@p_Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@p_Modo", "S"));
                    cmd.Parameters.Add(new SqlParameter("@usuario", "Admin"));  // Debe cambiar

                    sql.Open();
                    cmd.ExecuteReader();
                }
            }

            return "Ok";

        }

        #endregion

    }
}
