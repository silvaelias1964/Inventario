﻿using AutoMapper;
using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    /// <summary>
    /// Productos
    /// </summary>
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork unitOfWork;        
        private readonly IMapper mapper;
       
        // Constructor
        public ProductoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Traer todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> GetAll()
        {
            var entities = unitOfWork.Producto.GetAll();
            return (IEnumerable)entities;
        }

        /// <summary>
        /// Traer datos de un producto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto> GetById(int id)
        {
            Producto entities = unitOfWork.Producto.GetByID(id);
            return entities;
        }

        /// <summary>
        /// Agregar productos
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(ProductoModel model)
        {
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

                var entity = mapper.Map<Producto>(model); //Mapping con mapper
                entity.ProveedorId= entity.ProveedorId ==0 ? null: entity.ProveedorId;
                entity.CategoriaProductoId= entity.CategoriaProductoId == 0 ? null : entity.CategoriaProductoId;
                await unitOfWork.Producto.Add(entity);
                unitOfWork.Producto.Save();
                return "Ok";
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var msg = ex.InnerException;
                return "Error: " + error + " - " + msg;
            }
        }

        public async Task<string> Edit(ProductoModel model)
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
                var entity = mapper.Map<Producto>(model); //Mapping con mapper               
                entity.ProveedorId = entity.ProveedorId == 0 ? null : entity.ProveedorId;
                entity.CategoriaProductoId = entity.CategoriaProductoId == 0 ? null : entity.CategoriaProductoId;
                await unitOfWork.Producto.Update(entity);
                unitOfWork.Producto.Save();
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
        /// Borrar un producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Delete(int id)
        {
            try
            {
                await unitOfWork.Producto.Delete(id);
                unitOfWork.Producto.Save();

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
        /// Listado de Productos (combo)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ProductosList()
        {
            List<SelectListItem> lstSalida = new List<SelectListItem>();

            var lista = unitOfWork.Producto.GetAll();
            if (lista.Count() > 0)
            {
                foreach (var item in lista)
                {
                    lstSalida.Add(new SelectListItem() { Text = item.PrdCodigo+'-'+item.PrdNombre, Value = item.Id.ToString() });
                }
            }
            else
            {
                lstSalida.Add(new SelectListItem() { Text = "No hay productos", Value = "0" });
            }

            return lstSalida;
        }



    }
}
