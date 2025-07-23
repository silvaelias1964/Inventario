using CoreInventario.Application.DTOS;
using CoreInventario.Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        string EncriptarClave(string clave);

        /// <summary>
        /// Extraer el factor dolar del día
        /// </summary>
        /// <returns></returns>
        FactorMonedaModel FactorMoneda();

        /// <summary>
        /// Estatus de ordenes de compra
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> EstatusOdcList();

        /// <summary>
        /// Lista de productos
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> ProductosList();

        /// <summary>
        /// Lista de unidades de medida
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> UnidadMedidaList();

        /// <summary>
        /// Traer parametro
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        List<ParametroDTO> ValParametros(string valor);

        /// <summary>
        /// Moneda por defecto
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> MonedaDefList();

        /// <summary>
        /// Extraer usuario en sesión, para guardar log
        /// </summary>
        /// <returns>UsuarioSesionDTO</returns>
        UsuarioSesionDTO UsuarioLog(ClaimsPrincipal claimuser);
    }
}
