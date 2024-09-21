using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Configuracion : BaseAuditableEntity
    {
        // Datos generales de la empresa propietaria del sistema
        [MaxLength(100)]
        public string Empresa {  get; set; }
        [MaxLength(250)]
        public string Direccion { get; set; }
        [MaxLength(50)]
        public string Ciudad { get; set;}
        [MaxLength(50)]
        public string Pais {  get; set; }
        [MaxLength(50)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; }
        [MaxLength(100)]
        public string Contacto { get; set; }
        // Datos para procesos
        [MaxLength(20)]
        public string Iva { get; set;}        
        public decimal PorIva { get; set;}
        public int MonedaDefecto { get; set; }         
        // Configuración de servicios adicionales
        [MaxLength(100)]
        public string SmtpContrasena { get; set;}
        public int SmtpPuerto { get; set;}
        [MaxLength(200)]
        public string SmtpSender { get; set; }
        [MaxLength(200)]
        public string SmtpServidor { get; set; }
        public bool SmtpSSL { get; set;}
        [MaxLength(100)]
        public string SmtpNombreUsuario { get; set; }
        [MaxLength(100)]
        public string SmtpContrasenaUsuario { get; set;}
        [MaxLength(1)]
        public string TipoConfig { get; set;}  // (P)roduc. (D)esarr. (Q)a  (O)tro

    }
}
