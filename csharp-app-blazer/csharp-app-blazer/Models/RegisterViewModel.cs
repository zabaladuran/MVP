// Models/RegisterViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace csharp_app_blazer.Models
{
    public class RegisterViewModel
    {
        // Datos Personales
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento es obligatorio.")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string Correo { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe confirmar la contraseña.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarPassword { get; set; } = string.Empty;

        // Dirección Administrador
        [Required(ErrorMessage = "La nomenclatura es obligatoria.")]
        public string Nomenclatura { get; set; } = string.Empty;

        public string? Barrio { get; set; }
        public string? Notas { get; set; }
        public string? CodigoPostal { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un departamento.")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un municipio.")]
        public string Municipio { get; set; } = string.Empty;

        // Datos Tienda
        [Required(ErrorMessage = "El nombre comercial es obligatorio.")]
        public string NombreComercial { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
        public string? UrlLogo { get; set; }

        [Required(ErrorMessage = "El correo de la tienda es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string CorreoTienda { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono de la tienda es obligatorio.")]
        public string TelefonoTienda { get; set; } = string.Empty;

        [Required(ErrorMessage = "La razón social es obligatoria.")]
        public string RazonSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un plan.")]
        public string Plan { get; set; } = string.Empty;

        // Dirección Tienda
        [Required(ErrorMessage = "La nomenclatura de la tienda es obligatoria.")]
        public string TiendaNomenclatura { get; set; } = string.Empty;

        [Required(ErrorMessage = "El barrio de la tienda es obligatorio.")]
        public string TiendaBarrio { get; set; } = string.Empty;

        public string? TiendaNotas { get; set; }

        [Required(ErrorMessage = "El código postal de la tienda es obligatorio.")]
        public string TiendaCodigoPostal { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un departamento para la tienda.")]
        public string TiendaDepartamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un municipio para la tienda.")]
        public string TiendaMunicipio { get; set; } = string.Empty;
    }
}