using System;

namespace csharp_app.Models
{
    public class Tienda
    {
        public int Id { get; set; }
        public string NombreComercial { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string UrlLogo { get; set; } = string.Empty;
        public string CorreoAtencion { get; set; } = string.Empty;
        public string TelefonoAtencion { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string EstadoTienda { get; set; } = string.Empty;
        public DateTime FechaVencimientoSuscripcion { get; set; }
        public int PlanId { get; set; }

        public string EstadoLabel => EstadoTienda;
    }
}