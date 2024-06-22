using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class OrdenCompraDTO
    {
        public int Id { get; set; }
        public string OrdenCompraNro { get; set; }
        public string FechaOrden {  get; set; }
        public string FechaEmision { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public int EstatusId { get; set; }
        public OdcEstatusEnum Estatus { get; set; }
    }
}
