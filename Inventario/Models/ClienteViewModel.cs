using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [MaxLength(15)]
        public string CliCodigo { get; set; }

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
        public string CliContacto { get; set; }

        [Display(Name = "Título")]
        [MaxLength(50)]
        public string CliTitulo { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50)]
        public string CliDireccion1 { get; set; }

        [MaxLength(50)]
        public string CliDireccion2 { get; set; }

        [MaxLength(50)]
        public string CliDireccion3 { get; set; }

        [MaxLength(50)]
        public string CliDireccion4 { get; set; }

        [Display(Name = "Teléfono 1")]
        [MaxLength(30)]
        public string CliTelefono1 { get; set; }

        [Display(Name = "Teléfono 2")]
        [MaxLength(30)]
        public string CliTelefono2 { get; set; }

        [Display(Name = "Correo Electrónico")]
        [MaxLength(50)]
        public string CliCorreoE { get; set; }

        [Display(Name = "Estatus")]
        public int CliEstatus { get; set; }

    }
}
