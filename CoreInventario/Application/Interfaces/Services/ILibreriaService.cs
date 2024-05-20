using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{
    public interface ILibreriaService
    {
        /// <summary>
        /// Lista de categorias de producto
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> CategoriaProductoList();

        /// <summary>
        /// Lista de proveedores
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> ProveedorList();

        /// <summary>
        /// Estatus de proveedores
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> EstatusProveedorList();

        /// <summary>
        /// Estatus de cliente
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> EstatusClienteList();

        /// <summary>
        /// Tipo de cliente
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> TipoClienteList();

        /// <summary>
        /// Estatus de usuario
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> EstatusUsuarioList();

        /// <summary>
        /// Lista de Roles
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> RolesList();

        /// <summary>
        /// Crear cadena encriptada
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncriptarClave(string clave);
    }
}
