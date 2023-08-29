using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class ProveedorViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Código Proveedor")]
        [MaxLength(15)]
        public string? PrvCodigo { get; set; }

        [Display(Name = "Nombre de la compañía")]
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string PrvNombreCompania { get; set; }

        [Display(Name = "Contacto")]
        [MaxLength(50)]
        public string? PrvContacto { get; set; }

        [Display(Name = "Título contacto")]
        [MaxLength(50)]
        public string? PrvTituloContacto { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(500)]
        public string? PrvDireccion { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50)]
        public string? PrvCiudad { get; set; }

        [Display(Name = "Región")]
        [MaxLength(50)]
        public string? PrvRegion { get; set; }

        [Display(Name = "Código Postal")]
        [MaxLength(10)]
        public string? PrvCodigoPostal { get; set; }

        [Display(Name = "Teléfono Principal")]
        [MaxLength(25)]
        public string? PrvTelefono1 { get; set; }

        [Display(Name = "Teléfono Movil")]
        [MaxLength(25)]
        public string? PrvTelefono2 { get; set; }

        [Display(Name = "Teléfono Trabajo")]
        [MaxLength(25)]
        public string? PrvTelefono3 { get; set; }

        [Display(Name = "Correo Electrónico 1")]
        [MaxLength(50, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Email no es valido!")]
        public string? PrvCorreoE1 { get; set; }

        [Display(Name = "Correo Electrónico 2")]
        [MaxLength(50, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Email no es valido!")]
        public string? PrvCorreoE2 { get; set; }

        [Display(Name = "Pagina Web")]
        [MaxLength(100)]
        public string? PrvPagWeb { get; set; }

        [Display(Name = "Red Social 1")]
        [MaxLength(100)]
        public string? PrvRedSocial1 { get; set; }

        [Display(Name = "Red Social 2")]
        [MaxLength(100)]
        public string? PrvRedSocial2 { get; set; }

        [Display(Name = "Estatus")]
        [Required]
        public int PrvEstatus { get; set; }


        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref ProveedorModel model)
        {
            model.Id = Id;
            model.PrvCodigo = PrvCodigo;
            model.PrvNombreCompania = PrvNombreCompania;
            model.PrvContacto = PrvContacto;
            model.PrvTituloContacto = PrvTituloContacto;
            model.PrvDireccion = PrvDireccion;
            model.PrvCiudad = PrvCiudad;
            model.PrvRegion = PrvRegion;
            model.PrvCodigoPostal = PrvCodigoPostal;
            model.PrvTelefono1 = PrvTelefono1;
            model.PrvTelefono2 = PrvTelefono2;
            model.PrvTelefono3 = PrvTelefono3;
            model.PrvCorreoE1 = PrvCorreoE1;
            model.PrvCorreoE2 = PrvCorreoE2;
            model.PrvPagWeb = PrvPagWeb;
            model.PrvRedSocial1 = PrvRedSocial1;
            model.PrvRedSocial2 = PrvRedSocial2;
            model.PrvEstatus = PrvEstatus;

        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref Proveedor model)
        {
            Id = model.Id;
            PrvCodigo = model.PrvCodigo;
            PrvNombreCompania = model.PrvNombreCompania;
            PrvContacto = model.PrvContacto;
            PrvTituloContacto = model.PrvTituloContacto;
            PrvDireccion = model.PrvDireccion;
            PrvCiudad = model.PrvCiudad;
            PrvRegion = model.PrvRegion;
            PrvCodigoPostal = model.PrvCodigoPostal;
            PrvTelefono1 = model.PrvTelefono1;
            PrvTelefono2 = model.PrvTelefono2;
            PrvTelefono3 = model.PrvTelefono3;
            PrvCorreoE1 = model.PrvCorreoE1;
            PrvCorreoE2 = model.PrvCorreoE2;
            PrvPagWeb = model.PrvPagWeb;
            PrvRedSocial1 = model.PrvRedSocial1;
            PrvRedSocial2 = model.PrvRedSocial2;
            PrvEstatus = model.PrvEstatus;

        }


    }
}


