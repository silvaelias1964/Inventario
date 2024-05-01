using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Salida : BaseAuditableEntity
    {
        //[Required]
        public int? ProductoId { get; set; }

        [Required]
        public decimal SalPrecioUnidad { get; set; }

        [Required]
        public int SalStock { get; set; }

        [MaxLength(255)]
        [Required]
        public string SalDetalles { get; set; }

        [Required]
        public DateTime? SalFecha { get; set; }

        [Required]
        public int SalEstatus { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
