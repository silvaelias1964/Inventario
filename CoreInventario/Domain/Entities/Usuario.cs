using CoreInventario.Domain.Common;
using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public partial class Usuario : BaseAuditableEntity
    {
        
        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        public string Correo { get; set; }
        
        [MaxLength(255)]
        public string Clave { get; set; }

        [MaxLength(255)]
        public string Foto { get; set; }

        public bool IsNotificacion { get; set; }

        [Required]
        public UsuarioEstatusEnum EstatusUsuario { get; set; }

        public int? RolId { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
