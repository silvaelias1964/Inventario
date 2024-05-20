using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class CambiarClaveViewModel
    {
        public CambiarClaveViewModel()
        { }

        [Required(ErrorMessage = "Usuario requerido")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Clave actual")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Nueva clave")]
        public string NewPassword { get; set; }
    }
}
