using csharp_app_blazer.Data;
using MySql.Data.MySqlClient;

namespace csharp_app_blazer.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly DbConnectionFactory _db;

        public DashboardService(DbConnectionFactory db)
        {
            _db = db;
        }

        public async Task<List<TiendaInfo>> ObtenerTiendasAsync()
        {
            var tiendas = new List<TiendaInfo>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand("SELECT nTiendaID, cNombreComercial FROM TTiendas WHERE eEstadoTienda = 'Activa' ORDER BY cNombreComercial", conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                tiendas.Add(new(reader.GetInt32(0), reader.GetString(1)));
            return tiendas;
        }

        public async Task<TiendaInfo?> ObtenerTiendaPorNombreAsync(string nombre)
        {
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand("SELECT nTiendaID, cNombreComercial FROM TTiendas WHERE cNombreComercial = @nombre LIMIT 1", conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
                return new(reader.GetInt32(0), reader.GetString(1));
            return null;
        }

        public async Task<List<MetricaItem>> ObtenerMetricasAsync(int tiendaId)
        {
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();

            var totalProductos = 0;
            var cmd = new MySqlCommand("SELECT COUNT(*) FROM TProductos WHERE nTiendaFK = @id", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            totalProductos = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            var totalPedidos = 0;
            cmd = new MySqlCommand(@"
                SELECT COUNT(DISTINCT dp.nPedidoFK)
                FROM TDetallePedido dp
                INNER JOIN TProductos p ON dp.nProductoFK = p.nProductoID
                WHERE p.nTiendaFK = @id", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            totalPedidos = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            var ingresos = 0m;
            cmd = new MySqlCommand(@"
                SELECT COALESCE(SUM(ped.nTotal), 0)
                FROM TPedido ped
                WHERE ped.nPedidoID IN (
                    SELECT DISTINCT dp.nPedidoFK
                    FROM TDetallePedido dp
                    INNER JOIN TProductos p ON dp.nProductoFK = p.nProductoID
                    WHERE p.nTiendaFK = @id
                )", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            ingresos = Convert.ToDecimal(await cmd.ExecuteScalarAsync());

            var trabajadores = 0;
            cmd = new MySqlCommand("SELECT COUNT(*) FROM TTrabajadorTienda WHERE nTiendaFK = @id", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            trabajadores = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            return new()
            {
                new("Productos", totalProductos, "Registrados en el catálogo"),
                new("Pedidos", totalPedidos, "Realizados"),
                new("Ingresos", ingresos, "Totales"),
                new("Trabajadores", trabajadores, "Activos en la tienda"),
            };
        }

        public async Task<List<PedidoReciente>> ObtenerPedidosRecientesAsync(int tiendaId, int limite = 10)
        {
            var pedidos = new List<PedidoReciente>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand(@"
                SELECT DISTINCT ped.cNumeroComprobante,
                       CONCAT(c.cNombre, ' ', c.cApellido) AS Cliente,
                       ped.nTotal,
                       est.cNombreEstado
                FROM TPedido ped
                INNER JOIN TDetallePedido dp ON dp.nPedidoFK = ped.nPedidoID
                INNER JOIN TProductos p ON dp.nProductoFK = p.nProductoID
                INNER JOIN TUsuarioCliente c ON ped.nClienteFK = c.nUsuarioClienteID
                INNER JOIN TEstadoPedido est ON ped.nEstadoPedidoFK = est.nEstadoPedidoID
                WHERE p.nTiendaFK = @id
                ORDER BY ped.nPedidoID DESC
                LIMIT @limite", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            cmd.Parameters.AddWithValue("@limite", limite);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                pedidos.Add(new(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3)));
            return pedidos;
        }
    }
}
