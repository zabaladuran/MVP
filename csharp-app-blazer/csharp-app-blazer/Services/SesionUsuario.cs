namespace csharp_app_blazer.Services
{
    public class SesionUsuario
    {
        public int TrabajadorId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Tipo { get; set; } = "trabajador";
        public DateTime Expiracion { get; set; }
    }
}
