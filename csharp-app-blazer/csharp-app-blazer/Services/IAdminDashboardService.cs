namespace csharp_app_blazer.Services
{
    public record AdminTiendaInfo(int Id, string Nombre, string Estado, string? AdminNombre, string? AdminCorreo, int Trabajadores, DateTime? SuscripcionVence);
    public record AdminPqrsItem(int Id, string Ticket, string Tipo, string Estado, string Asunto, string Creador, string TipoCreador, DateTime Fecha);
    public record AdminTrabajadorItem(int Id, string Documento, string Nombre, string Apellido, string Correo, string Telefono, string Rol, string? Tienda);

    public interface IAdminDashboardService
    {
        Task<List<AdminTiendaInfo>> ObtenerTiendasAsync();
        Task<List<AdminPqrsItem>> ObtenerPqrsAsync();
        Task<List<AdminTrabajadorItem>> ObtenerTrabajadoresAsync();
        Task<List<AdminTrabajadorItem>> ObtenerTrabajadoresEditablesAsync(int adminRolId);
        Task<bool> CambiarPasswordAsync(int trabajadorId, string nuevaPassword);
    }
}
