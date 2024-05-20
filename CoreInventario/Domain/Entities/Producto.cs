using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Producto : BaseAuditableEntity
    {

        [MaxLength(15)]
        [Required]
        public string PrdCodigo { get; set; }
        [Required]
        [MaxLength(100)]
	    public string PrdNombre { get; set; }                
	    public int? CategoriaProductoId { get; set; }       
        public int? ProveedorId { get; set; }
        [MaxLength(20)]
        public string PrdCantPorUnidad { get; set; }
        [Required]
        public decimal PrdPrecioUnidad { get; set; }
        [Required]
        public int PrdStockMinimo { get; set; }
        [Required]
        public int PrdStock { get; set; }
        [Required]
        public int PrdEstatus { get; set; }

        [MaxLength(100)]
        public string PrdFoto1 { get; set; }

        [MaxLength(100)]
        public string PrdFoto2 { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }

    }
}
