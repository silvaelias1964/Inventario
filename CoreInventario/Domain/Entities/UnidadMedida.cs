using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class UnidadMedida : BaseAuditableEntity
    {
        [MaxLength(15)]
        [Required]
        public string UniCodigo { get; set; }

        [MaxLength(100)]
        [Required]
        public string UniDescripcion { get; set; }

        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }
    }
}
