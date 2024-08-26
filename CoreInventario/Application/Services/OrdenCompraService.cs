using AutoMapper;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;        

        // Constructor
        public OrdenCompraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;   
            this.mapper = mapper;
        }

        /// <summary>
        /// Traer todas las ODC
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> GetAll()
        {
            var entities = unitOfWork.OrdenCompra.GetAll();
            return (IEnumerable)entities;
        }

        /// <summary>
        /// Buscar orden de compra por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrdenCompraModel> GetById(int id)
        {
            // Cabecera            
            var entities = unitOfWork.OrdenCompra.GetByID(id);
            OrdenCompraModel ordencompraModel = new OrdenCompraModel
            {
                Id = entities.Id,
                OccNroOrden = entities.OccNroOrden,
                ProveedorId = entities.ProveedorId,                
                OccFechaEmision = entities.OccFechaEmision.GetValueOrDefault(),
                OccFechaOrden = entities.OccFechaOrden.GetValueOrDefault(), 
                OccFechaVencimiento = entities.OccFechaVencimiento.GetValueOrDefault(),
                OccDescuento = entities.OccDescuento,
                OccGasto =  entities.OccGasto,
                OccIVA = entities.OccIVA,
                OccCorreosElec = entities.OccCorreosElec,
                OccTelefonos = entities.OccTelefonos,
                OccDireccion = entities.OccDireccion,
                OccMismaDireccion= entities.OccMismaDireccion,
                OccObservaciones = entities.OccObservaciones,
                OccEstatus = entities.OccEstatus                
            };
            // Detalle
            var detalle = unitOfWork.OrdenCompra.GetByIDDetal(ordencompraModel.Id);
            foreach (var item in detalle)
            {
                ordencompraModel.OrdenCompraDetalleModels.Add(new OrdenCompraDetalleModel()
                {
                    Id = item.Id,
                    OrdenCompraId = item.OrdenCompraId,
                    ProductoId = item.ProductoId,
                    OcdCantidad = item.OcdCantidad,
                    //UnidadMedidaId = item.UnidadMedidaId,
                    OrdenCompra = item.OrdenCompra,
                    Producto=item.Producto
                    //UnidadMedida=item.UnidadMedida
                });
            }

            return ordencompraModel;
        }

        /// <summary>
        /// Agregar datos en Orden de compra
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(OrdenCompraModel model)
        {
            try
            {
                // Sesion
                //var sesion = sesionService.GetSesion();

                // Mapping if data correct
                OrdenCompra entity = new OrdenCompra
                {
                    OccNroOrden = model.OccNroOrden,
                    OccFechaEmision = model.OccFechaEmision,
                    OccFechaOrden = model.OccFechaOrden,
                    OccFechaVencimiento = model.OccFechaVencimiento,
                    ProveedorId = model.ProveedorId,
                    OccDescuento = model.OccDescuento,
                    OccGasto = model.OccGasto,
                    OccIVA = model.OccIVA,
                    OccCorreosElec = model.OccCorreosElec,
                    OccTelefonos = model.OccTelefonos,
                    OccDireccion = model.OccDireccion,
                    OccMismaDireccion = model.OccMismaDireccion,
                    OccObservaciones = model.OccObservaciones,
                    OccEstatus = model.OccEstatus
                };
                

                foreach (var item in model.OrdenCompraDetalleModels)
                {
                    var detalles = new OrdenCompraDetalle();
                    detalles.Id = item.Id;
                    detalles.OrdenCompraId = item.OrdenCompraId;
                    detalles.ProductoId = item.ProductoId;
                    detalles.OcdCantidad = item.OcdCantidad;
                    //detalles.UnidadMedidaId = item.UnidadMedidaId;
                    entity.AddOrdenCompraDetalle(detalles);

                }

                entity.OccNroOrden = CodeGenerate();
                entity.OccEstatus = 1;
                await unitOfWork.OrdenCompra.Add(entity);
                unitOfWork.OrdenCompra.Save();
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
        /// Modificar Orden de compra
        /// </summary>
        /// <param name=model></param>
        /// <returns></returns>
        public async Task<string> Edit(OrdenCompraModel model)
        {
            try
            {
                // Sesion
                //var sesion = sesionService.GetSesion();

                var entity = unitOfWork.OrdenCompra.GetByID(model.Id);


                // Borrado previo                
                unitOfWork.OrdenCompraDetalle.Delete(entity.Id);
                // Agregar nuevamente
                foreach (var item in model.OrdenCompraDetalleModels)
                {
                    var detalles = new OrdenCompraDetalle();
                    //detalles.Id = item.Id;
                    detalles.OrdenCompraId = item.OrdenCompraId;
                    detalles.ProductoId = item.ProductoId;
                    detalles.OcdCantidad = item.OcdCantidad;
                    //detalles.UnidadMedidaId = item.UnidadMedidaId;
                    entity.AddOrdenCompraDetalle(detalles);
                }


                // Detalle
                //var detalle = unitOfWork.OrdenCompra.GetByIDDetal(entity.Id);
                //foreach (var item in detalle)
                //{
                //    entity.OrdenCompraDetalles.Add(new OrdenCompraDetalle()
                //    {
                //        Id = item.Id,
                //        ProductoId = item.ProductoId,
                //        OcdCantidad = item.OcdCantidad,                        
                //        OrdenCompra = item.OrdenCompra,
                //        Producto = item.Producto
                //    });
                //}


                //var lstDetalles = entity.OrdenCompraDetalles.ToList();
                //foreach (var item in lstDetalles)
                //{
                //    var result = entity.OrdenCompraDetalles.FirstOrDefault(c => c.Id == item.Id);
                //    entity.RemoveOrdenCompraDetalle(result);
                //}

                //foreach (var item in model.OrdenCompraDetalleModels)
                //{
                //    var detalles = new OrdenCompraDetalle();
                //    detalles.Id = item.Id;
                //    detalles.ProductoId = item.ProductoId;
                //    detalles.OcdCantidad = item.OcdCantidad;
                //    //detalles.UnidadMedidaId = item.UnidadMedidaId;
                //    entity.AddOrdenCompraDetalle(detalles);
                //}


                // Datos de la cabecera

                entity.OccNroOrden = model.OccNroOrden;
                entity.OccFechaEmision = model.OccFechaEmision;
                entity.OccFechaOrden = model.OccFechaOrden;
                entity.OccFechaVencimiento = model.OccFechaVencimiento;
                entity.ProveedorId = model.ProveedorId;
                entity.OccDescuento = model.OccDescuento;
                entity.OccGasto = model.OccGasto;
                entity.OccIVA = model.OccIVA;
                entity.OccCorreosElec = model.OccCorreosElec;
                entity.OccTelefonos = model.OccTelefonos;
                entity.OccDireccion = model.OccDireccion;
                entity.OccMismaDireccion = model.OccMismaDireccion;
                entity.OccObservaciones = model.OccObservaciones;

                entity.OccEstatus = model.OccEstatus;
                

                 await unitOfWork.OrdenCompra.Update(entity);
                unitOfWork.OrdenCompra.Save();

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
        /// Borrar orden de compra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id)
        {
            try
            {

                var entity = unitOfWork.OrdenCompra.GetByID(id);
                unitOfWork.OrdenCompraDetalle.Delete(id);

                //var lstdetalles = entity.OrdenCompraDetalles.ToList();
                //foreach (var item in lstdetalles)
                //{
                //    var result = entity.OrdenCompraDetalles.FirstOrDefault(c => c.Id == item.Id);
                //    entity.RemoveOrdenCompraDetalle(result);
                //}

                await unitOfWork.OrdenCompra.Delete(entity);
                unitOfWork.OrdenCompra.Save();

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
        /// Generación automatica de código ODC
        /// </summary>
        /// <returns>string code</returns>
        private string CodeGenerate()
        {
            string codeGen = "";
            string strTYear = "";
            string strTMonth = "";
            string strRYear = "";
            string strRMonth = "";
            string fieldBeforeCode = "";
            string prefix = "";
            
            var lastRegister = unitOfWork.OrdenCompra.GetAll().OrderByDescending(c => c.Id).FirstOrDefault();
            if (lastRegister != null)
            {
                fieldBeforeCode = lastRegister.OrdenCompraNro;
            }
            else
            {
                fieldBeforeCode = "";  // zero records
            }

            // Date today
            DateTime toDay;
            toDay = DateTime.Now;
            strTYear = toDay.Year.ToString().Trim();
            strTYear = strTYear.Substring(2, 2);
            strTMonth = toDay.Month.ToString().Trim();
            strTMonth = strTMonth.Length == 1 ? "0" + strTMonth : strTMonth;
            // Date code
            if (fieldBeforeCode != prefix)
            {
                strRYear = fieldBeforeCode.Substring(0, 2);
                strRMonth = fieldBeforeCode.Substring(2, 2);
            }
            else  // zero records
            {
                strRYear = "00";
                strRMonth = "00";
                fieldBeforeCode = fieldBeforeCode + strRYear + strRMonth + "000";
            }
            // code registered
            string strBeforeCode = fieldBeforeCode.Substring(4);
            int intBeforecode = 0;  // counter register
            if (strTYear == strRYear && strTMonth == strRMonth)  // same month, increases from registration
            {
                intBeforecode = Convert.ToInt16(strBeforeCode) + 1;
                strBeforeCode = intBeforecode.ToString("D4");
                codeGen = prefix + strRYear + strRMonth + strBeforeCode;
            }
            else // different month, restart counter
            {
                intBeforecode = 1;
                strBeforeCode = intBeforecode.ToString("D4");
                codeGen = prefix + strTYear + strTMonth + strBeforeCode;
            }
            return codeGen;
        }


    }
}
