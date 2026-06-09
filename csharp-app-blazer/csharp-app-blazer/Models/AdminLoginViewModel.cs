using System.ComponentModel.DataAnnotations;

namespace csharp_app_blazer.Models
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }
}
