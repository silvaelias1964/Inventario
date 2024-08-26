using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class ConfiguracionModel
    {
        public int Id { get; set; }
        // Datos generales de la empresa propietaria del sistema        
        public string Empresa { get; set; }        
        public string Direccion { get; set; }        
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contacto { get; set; }
        // Datos para procesos
        public string Iva { get; set; }
        public decimal PorIva { get; set; }
        public int MonedaDefecto { get; set; }
        // Configuración de servicios adicionales
        public string SmtpContrasena { get; set; }
        public int SmtpPuerto { get; set; }
        public string SmtpSender { get; set; }
        public string SmtpSenvidor { get; set; }
        public bool SmtpSSL { get; set; }
        public string SmtpNombreUsuario { get; set; }
        public string SmtpContrasenaUsuario { get; set; }

    }
}
