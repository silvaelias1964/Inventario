using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class OrdenCompraDetalleModel
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int OcdCantidad { get; set; }
        //public int UnidadMedidaId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }
        public virtual Producto Producto { get; set; }
        //public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
