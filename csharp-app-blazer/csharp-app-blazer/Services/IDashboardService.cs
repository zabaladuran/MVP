namespace csharp_app_blazer.Services
{
    public record MetricaItem(string Titulo, decimal Valor, string Subtitulo);
    public record PedidoReciente(string Comprobante, string Cliente, decimal Total, string Estado);
    public record TiendaInfo(int Id, string Nombre);

    public interface IDashboardService
    {
        Task<List<TiendaInfo>> ObtenerTiendasAsync();
        Task<TiendaInfo?> ObtenerTiendaPorNombreAsync(string nombre);
        Task<List<MetricaItem>> ObtenerMetricasAsync(int tiendaId);
        Task<List<PedidoReciente>> ObtenerPedidosRecientesAsync(int tiendaId, int limite = 10);
    }
}
