using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class SalidaModel
    {
        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public decimal SalPrecioUnidad { get; set; }
        public int SalStock { get; set; }
        public string SalDetalles { get; set; }
        public DateTime? SalFecha { get; set; }
        public int SalEstatus { get; set; }
        public bool ActualizaInv { get; set; }  // Indicador de actualización de inventario

    }
}
