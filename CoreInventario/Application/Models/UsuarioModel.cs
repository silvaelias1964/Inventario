using CoreInventario.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Foto { get; set; }
        public bool IsNotificacion { get; set; }
        public UsuarioEstatusEnum EstatusUsuario { get; set; }
        public int RolId { get; set; }
        public int IsConfirmPass { get; set; }
        public IFormFile imagen { get; set; }
    }
}
