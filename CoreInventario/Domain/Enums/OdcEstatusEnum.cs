using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Enums
{

    public enum OdcEstatusEnum : int
    {
        [Description("Disponible/Activo")]
        Activo = 1,
        [Description("No Disponible/Inactivo")]
        Inactivo = 2,
        [Description("Suspendido")]
        Suspendido = 3

    }
}
