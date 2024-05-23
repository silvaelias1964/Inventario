using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]        
        [MaxLength(50)]
        public string? NombreUsuario { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        [MaxLength(255)]
        public string? Correo { get; set; }

        [Display(Name = "Clave de acceso")]
        //[Required(ErrorMessage = "El campo: {0} es requerido")]
        [MaxLength(255)]
        public string? Clave { get; set; }

        [Display(Name = "Foto")]
        [MaxLength(255)]
        public string? Foto { get; set; }

        [Display(Name = "¿ Desea notificaciones con su correo ?")]
        public bool IsNotificacion { get; set; }

        [Display(Name = "Estatus")]
        [Required]
        public UsuarioEstatusEnum EstatusUsuario { get; set; }

        [Display(Name = "Rol")]
        [Required]        
        public int RolId { get; set; }

        public int IsConfirmPass { get; set; }

        public IFormFile? imagen { get; set; }

        public int IsChangeImg { get; set; }

        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref UsuarioModel model)
        {
            model.Id = Id;
            model.NombreUsuario = NombreUsuario;
            model.Correo = Correo;
            model.Clave = Clave;
            model.Foto = Foto;
            model.IsNotificacion= IsNotificacion;
            model.RolId = RolId;
            model.IsConfirmPass = IsConfirmPass;
            model.imagen = imagen;
            model.IsChangeImg = IsChangeImg;
            
        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref Usuario model)
        {
            Id = model.Id;
            NombreUsuario = model.NombreUsuario;
            Correo = model.Correo;
            Clave = model.Clave;
            Foto = model.Foto;
            IsNotificacion = model.IsNotificacion;
            RolId = model.RolId.GetValueOrDefault();
        }



    }
}
