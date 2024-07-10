using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Parametro : BaseAuditableEntity
    {
        [MaxLength(50)]
        public string PrmNombre { get; set; }

        [MaxLength(100)]
        public string PrmValor { get; set; }

        [MaxLength(20)]
        public string PrmTipo { get; set; }
    }
}
