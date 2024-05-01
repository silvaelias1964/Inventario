using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class EntradaModel
    {
        public int Id { get; set; }
        public int? ProductodId { get; set; }
        public decimal EntPrecioUnidad { get; set; }
        public int EntStock { get; set; }
        public string EntDetalles { get; set; }
        public DateTime? EntFecha { get; set; }
        public int EntEstatus { get; set; }

    }


}
