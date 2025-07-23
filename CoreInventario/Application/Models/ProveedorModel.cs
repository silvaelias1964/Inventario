using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class ProveedorModel
    {
        public int Id { get; set; }
        
        public string PrvCodigo { get; set; }

        public string PrvNombreCompania { get; set; }

        public string PrvContacto { get; set; }

        public string PrvTituloContacto { get; set; }

        public string PrvDireccion { get; set; }

        public string PrvCiudad { get; set; }

        public string PrvRegion { get; set; }

        public string PrvCodigoPostal { get; set; }

        public string PrvTelefono1 { get; set; }

        public string PrvTelefono2 { get; set; }

        public string PrvTelefono3 { get; set; }

        public string PrvCorreoE1 { get; set; }

        public string PrvCorreoE2 { get; set; }

        public string PrvPagWeb { get; set; }

        public string PrvRedSocial1 { get; set; }

        public string PrvRedSocial2 { get; set; }

        public int PrvEstatus { get; set; }

        //public int? PrdId { get; set; }

        public virtual Producto Producto { get; set; }

        // Usuario en sesión
        public string? IdUsuarioSesion { get; set; }
        public string? UsuarioSesion { get; set; }
    }
}
