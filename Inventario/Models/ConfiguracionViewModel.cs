using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class ConfiguracionViewModel
    {
        public int Id { get; set; }
        // Datos generales de la empresa propietaria del sistema

        [Display(Name = "Empresa/Razón Social")]
        [MaxLength(100)]
        public string Empresa { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(250)]
        public string Direccion { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50)]
        public string Ciudad { get; set; }

        [Display(Name = "País")]
        [MaxLength(50)]
        public string Pais { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(50)]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        [MaxLength(100)]
        public string Correo { get; set; }

        [Display(Name = "Persona Contacto")]
        [MaxLength(100)]
        public string Contacto { get; set; }

        // Datos para procesos
        [Display(Name = "Nombre Impuesto Ventas")]
        [MaxLength(20)]
        public string Iva { get; set; }

        [Display(Name = "Porcentaje")]
        public decimal PorIva { get; set; }

        [Display(Name = "Moneda por defecto")]
        public int MonedaDefecto { get; set; }

        // Configuración de servicios adicionales
        [Display(Name = "Correo Electrónico")]
        //[Required(ErrorMessage = "Emisor/remitente SMTP requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Correo no valido.")]
        [MaxLength(50, ErrorMessage = "CodeMaxLength")]
        public string SmtpSender { get; set; }

        [Display(Name = "Servidor SMTP")]
        //[Required(ErrorMessage = "Servidor SMTP requerido")]
        [MaxLength(50, ErrorMessage = "El código no puede ser mayor a 50 caracteres.")]
        public string SmtpServidor { get; set; }

        [Display(Name = "Puerto")]
        //[Required(ErrorMessage = "Puerto SMTP requerido")]
        [MaxLength(3, ErrorMessage = "El puerto no puede tener sobrepasar 3 digitos.")]
        [RegularExpression(@"([0-9\s]+)", ErrorMessage = "Solo se permiten números")]
        public int SmtpPuerto { get; set; }

        [Display(Name = "Contraseña SMTP")]
        [Required(ErrorMessage = "Contraseña SMTP requerida.")]
        [MaxLength(20)]
        public string SmtpContrasena { get; set; }
        
        [Display(Name = "SSL")]
        public bool SmtpSSL { get; set; }

        [Display(Name = "Usuario autorizado")]
        [MaxLength(100)]
        public string SmtpNombreUsuario { get; set; }

        [Display(Name = "Contraseña usuario")]
        [MaxLength(100)]
        public string SmtpContrasenaUsuario { get; set; }

        [MaxLength(1)]
        public string TipoConfig { get; set; }  // (P)roduc. (D)esarr. (Q)a  (O)tro


        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref ConfiguracionModel model)
        {
            model.Id = Id;
            model.Empresa = Empresa;
            model.Direccion = Direccion;
            model.Ciudad = Ciudad;
            model.Pais = Pais;
            model.Telefono = Telefono;
            model.Correo = Correo;
            model.Contacto = Contacto;
            model.Iva = Iva;
            model.PorIva = PorIva;
            model.MonedaDefecto = MonedaDefecto;
            model.SmtpContrasena = SmtpContrasena;
            model.SmtpPuerto = SmtpPuerto;
            model.SmtpSender = SmtpSender;
            model.SmtpServidor = SmtpServidor;
            model.SmtpSSL = SmtpSSL;
            model.SmtpNombreUsuario = SmtpNombreUsuario;
            model.SmtpContrasenaUsuario = SmtpContrasenaUsuario;
            model.TipoConfig = TipoConfig;
            

        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(Configuracion model)
        {
            Id = model.Id;
            Empresa = model.Empresa;
            Direccion = model.Direccion;
            Ciudad = model.Ciudad;
            Pais = model.Pais;
            Telefono = model.Telefono;
            Correo = model.Correo;
            Contacto = model.Contacto;
            Iva = model.Iva;
            PorIva = model.PorIva;
            MonedaDefecto = model.MonedaDefecto;
            SmtpContrasena = model.SmtpContrasena;
            SmtpPuerto = model.SmtpPuerto;
            SmtpSender = model.SmtpSender;
            SmtpServidor = model.SmtpServidor;
            SmtpSSL = model.SmtpSSL;
            SmtpNombreUsuario = model.SmtpNombreUsuario;
            SmtpContrasenaUsuario = model.SmtpContrasenaUsuario;
            TipoConfig = model.TipoConfig;

        }



    }
}
