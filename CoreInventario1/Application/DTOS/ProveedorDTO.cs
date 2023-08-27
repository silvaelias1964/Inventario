using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class ProveedorDTO
    {
        public int Id { get; set; }
        public string PrvCodigo { get; set; }
        public string PrvNombreCompania { get; set; }
        public string PrvContacto { get; set; }
        public int PrvEstatus { get; set; }
        public ProveedorEstatusEnum proveedorEstatus { get; set; }

    }
}
