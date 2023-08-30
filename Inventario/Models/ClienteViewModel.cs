using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Doc. Identificación")]
        [MaxLength(15)]
        public string? CliCodigo { get; set; }

        [Display(Name = "Tipo Doc.")]
        [MaxLength(1)]
        [Required]
        public string CliTipo { get; set; }

        [Display(Name = "Razón Social")]
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string CliRazonSocial { get; set; }

        [Display(Name = "Contacto")]
        [MaxLength(50)]
        public string? CliContacto { get; set; }

        [Display(Name = "Título")]
        [MaxLength(50)]
        public string? CliTitulo { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(500)]
        public string? CliDireccion { get; set; }

        [Display(Name = "Teléfono 1")]
        [MaxLength(25)]
        public string? CliTelefono1 { get; set; }

        [Display(Name = "Teléfono 2")]
        [MaxLength(25)]
        public string? CliTelefono2 { get; set; }

        [Display(Name = "Correo Electrónico")]        
        [MaxLength(50, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Email no es valido!")]
        public string? CliCorreoE { get; set; }

        [Display(Name = "Estatus")]
        public int CliEstatus { get; set; }



        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref ClienteModel model)
        {
            model.Id = Id;
            model.CliCodigo = CliCodigo;
            model.CliTipo = CliTipo;
            model.CliRazonSocial = CliRazonSocial;
            model.CliContacto = CliContacto;
            model.CliTitulo = CliTitulo;
            model.CliDireccion = CliDireccion;
            model.CliTelefono1 = CliTelefono1;
            model.CliTelefono2 = CliTelefono2;
            model.CliCorreoE = CliCorreoE;
            model.CliEstatus = CliEstatus;

        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref Cliente model)
        {
            Id = model.Id;
            CliCodigo = model.CliCodigo;
            CliTipo = model.CliTipo;
            CliRazonSocial = model.CliRazonSocial;
            CliContacto = model.CliContacto;
            CliTitulo = model.CliTitulo;
            CliDireccion = model.CliDireccion;
            CliTelefono1 = model.CliTelefono1;
            CliTelefono2 = model.CliTelefono2;
            CliCorreoE = model.CliCorreoE;
            CliEstatus = model.CliEstatus;


        }


    }
}
