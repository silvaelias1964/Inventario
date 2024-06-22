using CoreInventario.Domain.Common;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{

    public class OrdenCompra : BaseAuditableEntity
    {
        public OrdenCompra()
        {
            _ordenCompraDetalle = new List<OrdenCompraDetalle>();                
        }


        [MaxLength(15)]
        [Required]
        public string OccNroOrden { get; set; }        
        
        [Required]
        public DateTime? OccFechaEmision { get; set; }
        
        [Required]
        public DateTime? OccFechaOrden { get; set; }

        public DateTime? OccFechaVencimiento { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        public decimal OccIVA { get; set; }
        public decimal OccDescuento { get; set; }
        public decimal OccGasto { get; set; }

        [Required]
        public int OccEstatus { get; set; }

        [MaxLength(100)]
        public string OccNombre { get; set; }
        [MaxLength(500)]
        public string OccDireccion { get; set; }
        [MaxLength(25)]
        public string OccTelefono1 { get; set; }
        [MaxLength(25)]
        public string OccTelefono2 { get; set; }
        [MaxLength(25)]
        public string OccTelefono3 { get; set; }

        public int OccMismaDireccion { get; set; }

        public virtual Proveedor Proveedor { get; set; }


        // Detalle OC
        private List<OrdenCompraDetalle> _ordenCompraDetalle = new List<OrdenCompraDetalle>();

        public virtual IList<OrdenCompraDetalle> OrdenCompraDetalles => _ordenCompraDetalle.ToList();

        public virtual void AddOrdenCompraDetalle(OrdenCompraDetalle ordenCompraDetalle)
        {
            ordenCompraDetalle.OrdenCompra = this;
            if (!_ordenCompraDetalle.Contains(ordenCompraDetalle))
            {
                _ordenCompraDetalle.Add(ordenCompraDetalle);
            }
        }

        public virtual void RemoveOrdenCompraDetalle(OrdenCompraDetalle ordenCompraDetalle)
        {
            if (_ordenCompraDetalle.Contains(ordenCompraDetalle))
            {
                _ordenCompraDetalle.Remove(ordenCompraDetalle);
            }
        }


    }

}
