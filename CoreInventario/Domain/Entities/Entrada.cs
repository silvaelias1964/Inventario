using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Entrada : BaseAuditableEntity
    {
        [Required]
        public int PrvId { get; set; }

        [Required]
        public decimal EntPrecioUnidad { get; set; }

        [Required]
        public int EntStock { get; set; }

        [MaxLength(255)]
        [Required]
        public string EntDetalles { get; set; }

        [Required]
        public DateTime? EntFecha { get; set; }

        [Required]
        public int EntEstatus { get; set; }

        //public virtual Producto Producto { get; set; }
        

    }
}
