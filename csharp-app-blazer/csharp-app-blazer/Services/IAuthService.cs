namespace csharp_app_blazer.Services
{
    public interface IAuthService
    {
        Task<LoginResultado> LoginAsync(string correo, string password);
    }

    public class LoginResultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public int? UsuarioId { get; set; }
        public string? Nombre { get; set; }
    }
}
