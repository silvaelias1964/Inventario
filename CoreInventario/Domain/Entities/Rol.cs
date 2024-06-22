using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class Rol : BaseAuditableEntity
    {
        [MaxLength(10)]
        [Required]
        public string RolCodigo { get; set; }

        [MaxLength(100)]
        [Required]
        public string RolNombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
