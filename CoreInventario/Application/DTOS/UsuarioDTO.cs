using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Foto { get; set; }
        public int EstatusUsuario { get; set; }
        public UsuarioEstatusEnum usuarioEstatus { get; set; }
    }
}
