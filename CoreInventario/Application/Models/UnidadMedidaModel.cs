using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class UnidadMedidaModel
    {
        public int Id { get; set; } 

        [MaxLength(15)]
        [Required]
        public string UniCodigo { get; set; }

        [MaxLength(100)]
        [Required]
        public string UniDescripcion { get; set; }
    }
}
