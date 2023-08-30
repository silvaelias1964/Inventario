using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Proveedor : BaseAuditableEntity
    {

        [MaxLength(15)]
        public string PrvCodigo { get; set; }
		[Required]
        [MaxLength(100)]
        public string PrvNombreCompania { get; set; }
        [MaxLength(50)]
		public string? PrvContacto { get; set; }
        [MaxLength(50)]
		public string? PrvTituloContacto { get; set; }
        [MaxLength(500)]
		public string? PrvDireccion { get; set; }
        [MaxLength(50)]
		public string? PrvCiudad { get; set; }
        [MaxLength(50)]
		public string? PrvRegion { get; set; }
        [MaxLength(10)]
		public string? PrvCodigoPostal { get; set; }
        [MaxLength(25)]
		public string? PrvTelefono1 { get; set; }
        [MaxLength(25)]
		public string? PrvTelefono2 { get; set; }
        [MaxLength(25)]
		public string? PrvTelefono3 { get; set; }
        [MaxLength(50)]
		public string? PrvCorreoE1 { get; set; }
        [MaxLength(50)]
		public string? PrvCorreoE2 { get; set; }
        [MaxLength(100)]
		public string? PrvPagWeb { get; set; }
        [MaxLength(100)]
		public string? PrvRedSocial1 { get; set; }
        [MaxLength(100)]
		public string? PrvRedSocial2 { get; set; }
        [Required]
		public int PrvEstatus { get; set; }

        //public int? PrdId { get; set; }

        public ICollection<Producto> Producto { get; set; }
        
    }
}
