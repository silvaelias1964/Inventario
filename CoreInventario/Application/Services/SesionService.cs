using CoreInventario.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    public class SesionService : ISesionService
    {
        private readonly IHttpContextAccessor _httpContext;
        private ISession _session => _httpContext.HttpContext.Session;

        public SesionService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }



        /// <summary>
        /// Asignar valores de sesion
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserName"></param>
        public bool SetSesion(int Id, string UserName)
        {
            if (!string.IsNullOrEmpty(UserName) && Id != 0)
            {
                _session.SetInt32("Id", Id);
                _session.SetString("UserName", UserName);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Obtener valores de sesion
        /// </summary>
        /// <returns></returns>
        public string[] GetSesion()
        {

            string[] sesion = new string[2];
            int? Id = _session.GetInt32("Id");
            string UserName = _session.GetString("UserName");
            sesion[0] = Id.ToString();
            sesion[1] = UserName;
            return sesion;
        }




    }
}
