using csharp_app_blazer.Data;
using MySql.Data.MySqlClient;

namespace csharp_app_blazer.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly DbConnectionFactory _db;
        private const string DATE_FMT = "yyyy-MM-dd";

        public AdminDashboardService(DbConnectionFactory db)
        {
            _db = db;
        }

        public async Task<List<AdminTiendaInfo>> ObtenerTiendasAsync()
        {
            var result = new List<AdminTiendaInfo>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(@"
                SELECT
                    t.nTiendaID,
                    t.cNombreComercial,
                    t.eEstadoTienda,
                    t.dFechaVencimientoSuscripcion,
                    tr.nTrabajadorID,
                    CONCAT(tr.cNombre, ' ', tr.cApellido),
                    tr.cCorreo,
                    (SELECT COUNT(*) FROM TTrabajadorTienda WHERE nTiendaFK = t.nTiendaID)
                FROM TTiendas t
                LEFT JOIN TTrabajadorTienda tt ON t.nTiendaID = tt.nTiendaFK AND tt.nTrabajadorFK = (
                    SELECT MIN(tt2.nTrabajadorFK) FROM TTrabajadorTienda tt2
                    INNER JOIN TTrabajador tr2 ON tt2.nTrabajadorFK = tr2.nTrabajadorID
                    WHERE tt2.nTiendaFK = t.nTiendaID AND tr2.nRolFK = 2
                    LIMIT 1
                )
                LEFT JOIN TTrabajador tr ON tt.nTrabajadorFK = tr.nTrabajadorID
                ORDER BY t.cNombreComercial", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new AdminTiendaInfo(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.IsDBNull(5) ? null : reader.GetString(5),
                    reader.IsDBNull(6) ? null : reader.GetString(6),
                    reader.GetInt32(7),
                    reader.IsDBNull(3) ? null : reader.GetDateTime(3).ToLocalTime()
                ));
            }
            return result;
        }

        public async Task<List<AdminPqrsItem>> ObtenerPqrsAsync()
        {
            var result = new List<AdminPqrsItem>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(@"
                SELECT
                    p.nPQRSID,
                    p.cNumeroTicket,
                    p.eTipo,
                    p.eEstado,
                    p.cAsunto,
                    CASE
                        WHEN p.cTipoCreador = 'Usuario' THEN (
                            SELECT CONCAT(cNombre, ' ', cApellido) FROM TUsuarioCliente WHERE nUsuarioClienteID = p.nCreadorFK
                        )
                        WHEN p.cTipoCreador IN ('Tienda','Admin') THEN (
                            SELECT CONCAT(cNombre, ' ', cApellido) FROM TTrabajador WHERE nTrabajadorID = p.nCreadorFK
                        )
                        ELSE 'Desconocido'
                    END AS Creador,
                    p.cTipoCreador,
                    p.dFechaCreacion
                FROM TPQRS p
                ORDER BY p.dFechaCreacion DESC", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new AdminPqrsItem(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetDateTime(7).ToLocalTime()
                ));
            }
            return result;
        }

        public async Task<List<AdminTrabajadorItem>> ObtenerTrabajadoresAsync()
        {
            return await ObtenerTrabajadoresPorRol(null);
        }

        public async Task<List<AdminTrabajadorItem>> ObtenerTrabajadoresEditablesAsync(int adminRolId)
        {
            return await ObtenerTrabajadoresPorRol(adminRolId);
        }

        private async Task<List<AdminTrabajadorItem>> ObtenerTrabajadoresPorRol(int? excluirRolId)
        {
            var result = new List<AdminTrabajadorItem>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();

            var where = excluirRolId.HasValue
                ? "WHERE tr.nRolFK != @excluirRol"
                : "";

            using var cmd = new MySqlCommand($@"
                SELECT
                    tr.nTrabajadorID,
                    tr.cIdentificacion,
                    tr.cNombre,
                    tr.cApellido,
                    tr.cCorreo,
                    tr.cTelefono,
                    r.cNombre AS Rol,
                    (SELECT GROUP_CONCAT(t.cNombreComercial SEPARATOR ', ') FROM TTrabajadorTienda tt
                     INNER JOIN TTiendas t ON tt.nTiendaFK = t.nTiendaID
                     WHERE tt.nTrabajadorFK = tr.nTrabajadorID)
                FROM TTrabajador tr
                INNER JOIN TRoles r ON tr.nRolFK = r.nRolID
                {where}
                ORDER BY tr.cNombre, tr.cApellido", conn);

            if (excluirRolId.HasValue)
                cmd.Parameters.AddWithValue("@excluirRol", excluirRolId.Value);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new AdminTrabajadorItem(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? "" : reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.IsDBNull(5) ? "" : reader.GetString(5),
                    reader.GetString(6),
                    reader.IsDBNull(7) ? null : reader.GetString(7)
                ));
            }
            return result;
        }

        public async Task<List<AdminTrabajadorItem>> ObtenerTrabajadoresPorTiendaAsync(int tiendaId)
        {
            var result = new List<AdminTrabajadorItem>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(@"
                SELECT
                    tr.nTrabajadorID,
                    tr.cIdentificacion,
                    tr.cNombre,
                    tr.cApellido,
                    tr.cCorreo,
                    tr.cTelefono,
                    r.cNombre AS Rol
                FROM TTrabajador tr
                INNER JOIN TTrabajadorTienda tt ON tr.nTrabajadorID = tt.nTrabajadorFK
                INNER JOIN TRoles r ON tr.nRolFK = r.nRolID
                WHERE tt.nTiendaFK = @tiendaId
                ORDER BY tr.cNombre, tr.cApellido", conn);
            cmd.Parameters.AddWithValue("@tiendaId", tiendaId);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new AdminTrabajadorItem(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? "" : reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.IsDBNull(5) ? "" : reader.GetString(5),
                    reader.GetString(6),
                    null
                ));
            }
            return result;
        }

        public async Task<bool> CambiarPasswordAsync(int trabajadorId, string nuevaPassword)
        {
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();

            var hash = BCrypt.Net.BCrypt.HashPassword(nuevaPassword);
            using var cmd = new MySqlCommand(
                "UPDATE TTrabajador SET cPassword = @hash WHERE nTrabajadorID = @id",
                conn);
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@id", trabajadorId);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
    }
}
