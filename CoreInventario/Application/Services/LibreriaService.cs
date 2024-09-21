using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CoreInventario.Application.Models;
using CoreInventario.Transversal.Commons;
using Newtonsoft.Json.Linq;
using CoreInventario.Application.DTOS;

namespace CoreInventario.Application.Services
{
    public class LibreriaService : ILibreriaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPathConfiguration pathConfiguration;

        public LibreriaService(IUnitOfWork unitOfWork,IPathConfiguration pathConfiguration)
        {
            this.unitOfWork = unitOfWork;
            this.pathConfiguration = pathConfiguration;
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

        /// <summary>
        /// Estatus Usuarios
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> EstatusUsuarioList()
        {
            List<SelectListItem> lstEstatus = new List<SelectListItem>();

            foreach (var option in Enum.GetValues(typeof(UsuarioEstatusEnum)))
            {
                lstEstatus.Add(new SelectListItem { Text = Enum.GetName(typeof(UsuarioEstatusEnum), (int)option), Value = ((int)option).ToString() });
            }
            return lstEstatus;
        }

        /// <summary>
        /// Listado de roles
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> RolesList()
        {
            List<SelectListItem> lstRoles = new List<SelectListItem>();
            var lista = unitOfWork.Rol.GetAll();
            if (lista != null)
            {
                foreach (var item in lista.Result)
                {
                    lstRoles.Add(new SelectListItem() { Text = item.RolNombre, Value = item.Id.ToString() });
                }
            }
            else
            {
                lstRoles.Add(new SelectListItem() { Text = "No hay roles", Value = "0" });
            }
            return lstRoles;
        }

        

        /// <summary>
        /// Crear cadena encriptada
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncriptarClave(string clave)
        {
            if (clave == "" || clave == null)
                return "";

            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(clave));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();


            //StringBuilder sb = new StringBuilder();
            //using (SHA256 hash = SHA256.Create())
            //{
            //    Encoding enc = Encoding.UTF8;
            //    byte[] result = hash.ComputeHash(enc.GetBytes(clave));
            //    foreach (byte b in result)
            //        sb.Append(b.ToString("x2"));
            //}

            //return sb.ToString();
        }

        /// <summary>
        /// Extraer el factor dolar del día
        /// </summary>
        /// <returns>FactorMonedaModel</returns>
        public FactorMonedaModel FactorMoneda()
        {
            var client = new HttpClient();

            HttpClient _httpclie;
            HttpRequestMessage _httpreq;
            string serialapi = "";
            string querystring = "";
            _httpclie = new HttpClient();
            string url = pathConfiguration.PathFactor1;
            _httpclie.BaseAddress = new Uri(url);
            _httpclie.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpreq = new HttpRequestMessage();
            _httpreq.Method = HttpMethod.Get;
            _httpreq.RequestUri = new Uri(_httpclie.BaseAddress.AbsoluteUri + querystring + serialapi);
            HttpResponseMessage _httpresp = _httpclie.SendAsync(_httpreq).Result;
            if (_httpresp.StatusCode == HttpStatusCode.OK)
            {
                string jsonstring = _httpresp.Content.ReadAsStringAsync().Result;

                dynamic jsonObj = JObject.Parse(jsonstring);

                //List<FactorMonedaModel> datos = JsonConvert.DeserializeObject<List<FactorMonedaModel>>(jsonstring);
                //FactMoneda datos = JsonConvert.DeserializeObject<FactMoneda>(jsonstring);

                var datos=new List<FactorMonedaModel>();
                datos.Add(new FactorMonedaModel
                {
                    currency = "Dolar",
                    date = jsonObj.last_update,
                    exchange = jsonObj.price
                });


                return datos[0];

            }
            else
            {

                List<FactorMonedaModel> datos = new List<FactorMonedaModel>();
                datos.Add(new FactorMonedaModel() { currency = "", date = new DateTime().ToShortDateString(), exchange = 0 });
                return datos[0];
            }
        }

        /// <summary>
        /// Estatus Ordenes de compra
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> EstatusOdcList()
        {
            List<SelectListItem> lstEstatus = new List<SelectListItem>();

            foreach (var option in Enum.GetValues(typeof(OdcEstatusEnum)))
            {
                lstEstatus.Add(new SelectListItem { Text = Enum.GetName(typeof(OdcEstatusEnum), (int)option), Value = ((int)option).ToString() });
            }
            return lstEstatus;
        }

        /// <summary>
        /// Lista de productos
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ProductosList()
        {
            List<SelectListItem> lstResultado = new List<SelectListItem>();

            var lista = unitOfWork.Producto.GetAll().OrderBy(e=>e.PrdNombre);
            if (lista.Count() > 0)
            {
                foreach (var item in lista)
                {
                    lstResultado.Add(new SelectListItem() { Text = item.PrdNombre, Value = item.Id.ToString() });
                }
            }
            else
            {
                lstResultado.Add(new SelectListItem() { Text = "No hay productos", Value = "0" });
            }   
            return lstResultado;
        }

        /// <summary>
        /// Lista de unidades de medida
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> UnidadMedidaList()
        {
            List<SelectListItem> lstUnidad = new List<SelectListItem>();
            var lista = unitOfWork.UnidadMedida.GetAll();
            if (lista != null)
            {
                foreach (var item in lista.Result)
                {
                    lstUnidad.Add(new SelectListItem() { Text = item.UniDescripcion, Value = item.Id.ToString() });
                }
            }
            else
            {
                lstUnidad.Add(new SelectListItem() { Text = "No hay unidades de medida", Value = "0" });
            }

            return lstUnidad;
        }

        /// <summary>
        /// Traer parametro
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public List<ParametroDTO> ValParametros(string valor)     //ParametroDTO ValParametros(string valor)
        {
            //ParametroDTO result = new ParametroDTO();
            List<ParametroDTO> result = new List<ParametroDTO>();

            var registro = unitOfWork.Parametro.GetByNombre(valor);
            if(registro != null )
            {
                //result.Nombre = registro.PrmNombre;
                //result.Valor = registro.PrmValor;
                //result.Tipo = registro.PrmTipo;
                result.Add(new ParametroDTO
                {
                    Id = registro.Id,
                    Nombre= registro.PrmNombre,
                    Tipo = registro.PrmTipo,
                    Valor = registro.PrmValor
                });

            }
            return result;
        }


        /// <summary>
        /// Moneda por defecto
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> MonedaDefList()
        {
            List<SelectListItem> lstLista = new List<SelectListItem>();
            var lista = unitOfWork.UnidadMedida.GetAll();
            lstLista.Add(new SelectListItem() { Text = "Bs - Bolivar", Value = "0" });
            lstLista.Add(new SelectListItem() { Text = "$  - Dolar", Value = "1" });

            return lstLista;
        }



    }
}
