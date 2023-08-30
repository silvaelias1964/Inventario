using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Enums
{
    public enum ProductoEstatusEnum : int
    {
        [Description("Disponible/Activo")]
        Disponible = 1,
        [Description("No Disponible/Inactivo")]
        NoDisponible = 2,
        [Description("Descontinuado")]
        Descontinuado = 3
    }
}
