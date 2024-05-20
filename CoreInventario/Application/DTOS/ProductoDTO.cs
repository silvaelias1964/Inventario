using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string PrdCodigo { get; set; }
        public string PrdNombre { get; set; }
        public int CategoriaProductoId { get; set; }
        public string CatDescripcion { get; set;}
        public int ProveedorId { get; set; }
        public string PrvNombreCompania { get; set; }
        public int PrdEstatus { get; set; }
        public ProductoEstatusEnum productoEstatus  { get; set; }
    }
}
