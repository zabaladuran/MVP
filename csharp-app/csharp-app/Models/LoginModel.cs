namespace csharp_app.Models
{
    public class LoginModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}