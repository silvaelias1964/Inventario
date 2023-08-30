using CoreInventario.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Entities
{
    public class CategoriaProducto : BaseAuditableEntity
    {
        [Display(Name = "Nombre Categoría")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]        
        public required string CatNombreCategoria { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string CatDescripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
