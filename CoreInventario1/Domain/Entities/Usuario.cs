using CoreInventario.Domain.Common;
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

        public string Correo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Clave { get; set; }

        [MaxLength(255)]
        public string Foto { get; set; }


    }
}
