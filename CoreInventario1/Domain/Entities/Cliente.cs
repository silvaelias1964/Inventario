using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Cliente : BaseAuditableEntity
    {
		[MaxLength(15)]
        public string CliCodigo { get; set; }
		[MaxLength(1)]
		[Required]
		public string CliTipo { get; set; }
        [Required]
        [StringLength(100)]
        public string CliRazonSocial { get; set; }
        [MaxLength(50)]
        public string? CliContacto { get; set; }
        [MaxLength(50)]
        public string? CliTitulo { get; set; }
        [MaxLength(500)]
        public string? PrvDireccion { get; set; }
        [MaxLength(25)]
        public string? CliTelefono1 { get; set; }
        [MaxLength(25)]
        public string? CliTelefono2 { get; set; }
        [MaxLength(50)]
        public string? CliCorreoE { get; set; }
        [Required]
        public int CliEstatus { get; set; }

    }
}
