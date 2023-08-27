using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime FechaCreacion { get; set; }
        [MaxLength(100)]
        public string? CreadoPor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        [MaxLength(100)]
        public string? ActualizadoPor { get; set; }
    }
}
