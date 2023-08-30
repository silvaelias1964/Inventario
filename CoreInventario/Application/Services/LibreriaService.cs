using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    public class LibreriaService : ILibreriaService
    {
        private readonly IUnitOfWork unitOfWork;

        public LibreriaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> CategoriaProductoList()
        {
            List<SelectListItem>  lstSalida = new List<SelectListItem>();
            var lista = unitOfWork.CategoriaProducto.GetAll();
            if (lista!=null)
            {
                foreach (var item in lista.Result)
                {
                    lstSalida.Add(new SelectListItem() { Text = item.CatDescripcion, Value = item.Id.ToString() });
                }
            }
            else
            {
                lstSalida.Add(new SelectListItem() { Text = "No hay categorias", Value = "0" });
            }

            return lstSalida;
        }

        /// <summary>
        /// Listado de Proveedores
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ProveedorList()
        {
            List<SelectListItem> lstSalida = new List<SelectListItem>();            

            var lista = unitOfWork.Proveedor.GetAll();
            if(lista.Count()>0)
            {
                foreach (var item in lista)
                {
                    lstSalida.Add(new SelectListItem() { Text = item.PrvNombreCompania, Value = item.Id.ToString() });
                }
            }
            else
            {
                lstSalida.Add(new SelectListItem() { Text = "No hay proveedores", Value = "0" });
            }

            return lstSalida;
        }

        /// <summary>
        /// Estatus Proveedor
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> EstatusProveedorList()
        {
            List<SelectListItem> lstEstatus = new List<SelectListItem>();

            foreach (var option in Enum.GetValues(typeof(ProveedorEstatusEnum)))
            {
                lstEstatus.Add(new SelectListItem { Text = Enum.GetName(typeof(ProveedorEstatusEnum), (int)option), Value = ((int)option).ToString() });
            }
            return lstEstatus;
        }

        /// <summary>
        /// Estatus Cliente
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> EstatusClienteList()
        {
            List<SelectListItem> lstEstatus = new List<SelectListItem>();

            foreach (var option in Enum.GetValues(typeof(ClienteEstatusEnum)))
            {
                lstEstatus.Add(new SelectListItem { Text = Enum.GetName(typeof(ClienteEstatusEnum), (int)option), Value = ((int)option).ToString() });
            }
            return lstEstatus;
        }

        
        /// <summary>
        /// Tipo de cliente
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> TipoClienteList()
        {
            List<SelectListItem> lstEstatus = new List<SelectListItem>();

            foreach (var option in Enum.GetValues(typeof(TipoClienteEnum)))
            {
                lstEstatus.Add(new SelectListItem { Text = Enum.GetName(typeof(TipoClienteEnum), (int)option), Value = ((int)option).ToString() });
            }
            return lstEstatus;
        }

    }
}
