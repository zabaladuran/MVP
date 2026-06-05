using MySql.Data.MySqlClient;
using csharp_app_blazer.Data;
using csharp_app_blazer.Models;

namespace csharp_app_blazer.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly DbConnectionFactory _connectionFactory;

        public RegistroService(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<DepartamentoInfo>> ObtenerDepartamentos()
        {
            var result = new List<DepartamentoInfo>();

            using var conn = _connectionFactory.CreateConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("SELECT nDepartamentoID, cNombre FROM TDepartamento ORDER BY cNombre", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new DepartamentoInfo
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                });
            }

            return result;
        }

        public async Task<List<MunicipioInfo>> ObtenerMunicipios(int departamentoId)
        {
            var result = new List<MunicipioInfo>();

            using var conn = _connectionFactory.CreateConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand("SELECT nMunicipioID, nDepartamentoFK, cNombre FROM TMunicipio WHERE nDepartamentoFK = @depId ORDER BY cNombre", conn);
            cmd.Parameters.Add(new MySqlParameter("@depId", departamentoId));

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new MunicipioInfo
                {
                    Id = reader.GetInt32(0),
                    DepartamentoId = reader.GetInt32(1),
                    Nombre = reader.GetString(2)
                });
            }

            return result;
        }

        public async Task<RegistroResultado> RegistrarAdministrador(RegisterViewModel model)
        {
            using var conn = _connectionFactory.CreateConnection();
            await conn.OpenAsync();

            using var tx = conn.BeginTransaction();

            try
            {
                var cmd = new MySqlCommand { Connection = conn, Transaction = tx };

                var depId = await ObtenerOInsertarDepartamento(cmd, model.Departamento);
                var munId = await ObtenerOInsertarMunicipio(cmd, model.Municipio, depId);
                var dirAdminId = await InsertarDireccion(cmd, model.Nomenclatura, model.Barrio ?? "", model.Notas ?? "", model.CodigoPostal ?? "", munId);
                var depTiendaId = await ObtenerOInsertarDepartamento(cmd, model.TiendaDepartamento);
                var munTiendaId = await ObtenerOInsertarMunicipio(cmd, model.TiendaMunicipio, depTiendaId);
                var dirTiendaId = await InsertarDireccion(cmd, model.TiendaNomenclatura, model.TiendaBarrio ?? "", model.TiendaNotas ?? "", model.TiendaCodigoPostal ?? "", munTiendaId);
                var usuarioId = await InsertarUsuarioCliente(cmd, model.Nombre, model.Apellido, model.Documento, model.Correo, model.Telefono ?? "", model.Password, dirAdminId);
                await InsertarDireccionCliente(cmd, usuarioId, dirAdminId, "Casa", $"{model.Nombre} {model.Apellido}", model.Telefono ?? "");
                await InsertarTienda(cmd, model.NombreComercial, model.Descripcion ?? "", model.UrlLogo ?? "", model.CorreoTienda, model.TelefonoTienda, model.RazonSocial, dirTiendaId, model.TiendaCodigoPostal ?? "", model.Plan);

                tx.Commit();
                return new RegistroResultado { Exitoso = true, Mensaje = "Registro completado exitosamente." };
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return new RegistroResultado { Exitoso = false, Mensaje = $"Error al registrar: {ex.Message}" };
            }
        }

        private async Task<int> ObtenerOInsertarDepartamento(MySqlCommand cmd, string nombre)
        {
            cmd.CommandText = "SELECT nDepartamentoID FROM TDepartamento WHERE cNombre = @nombre";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));

            var existing = await cmd.ExecuteScalarAsync();
            if (existing != null)
                return Convert.ToInt32(existing);

            cmd.CommandText = "INSERT INTO TDepartamento (cNombre, cCodigoDane) VALUES (@nombre, '')";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            await cmd.ExecuteNonQueryAsync();

            cmd.CommandText = "SELECT LAST_INSERT_ID()";
            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        private async Task<int> ObtenerOInsertarMunicipio(MySqlCommand cmd, string nombre, int departamentoId)
        {
            cmd.CommandText = "SELECT nMunicipioID FROM TMunicipio WHERE cNombre = @nombre AND nDepartamentoFK = @depId";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@depId", departamentoId));

            var existing = await cmd.ExecuteScalarAsync();
            if (existing != null)
                return Convert.ToInt32(existing);

            cmd.CommandText = "INSERT INTO TMunicipio (nDepartamentoFK, cNombre, cCodigoDane) VALUES (@depId, @nombre, '')";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@depId", departamentoId));
            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            await cmd.ExecuteNonQueryAsync();

            cmd.CommandText = "SELECT LAST_INSERT_ID()";
            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        private async Task<int> InsertarDireccion(MySqlCommand cmd, string nomenclatura, string barrio, string notas, string codigoPostal, int municipioId)
        {
            cmd.CommandText = @"INSERT INTO TDireccion (cNomenclatura, cBarrio, cNotasAdicionales, cCodigoPostal, nMunicipioFK)
                                VALUES (@nomenclatura, @barrio, @notas, @codigoPostal, @municipioId);
                                SELECT LAST_INSERT_ID();";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@nomenclatura", nomenclatura));
            cmd.Parameters.Add(new MySqlParameter("@barrio", barrio));
            cmd.Parameters.Add(new MySqlParameter("@notas", notas));
            cmd.Parameters.Add(new MySqlParameter("@codigoPostal", codigoPostal));
            cmd.Parameters.Add(new MySqlParameter("@municipioId", municipioId));

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        private async Task<int> InsertarUsuarioCliente(MySqlCommand cmd, string nombre, string apellido, string documento, string correo, string telefono, string password, int direccionId)
        {
            cmd.CommandText = @"INSERT INTO TUsuarioCliente (cNombre, cApellido, cDocumento, cContrasena, cCorreo, cTelefono, nDireccionFK)
                                VALUES (@nombre, @apellido, @documento, @password, @correo, @telefono, @direccionId);
                                SELECT LAST_INSERT_ID();";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
            cmd.Parameters.Add(new MySqlParameter("@documento", documento));
            cmd.Parameters.Add(new MySqlParameter("@password", BCryptPasswordHash(password)));
            cmd.Parameters.Add(new MySqlParameter("@correo", correo));
            cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
            cmd.Parameters.Add(new MySqlParameter("@direccionId", direccionId));

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        private async Task InsertarDireccionCliente(MySqlCommand cmd, int clienteId, int direccionId, string etiqueta, string nombreRecibidor, string telefono)
        {
            cmd.CommandText = @"INSERT INTO TDireccionCliente (nClienteFK, nDireccionFK, cEtiqueta, cNombreRecibidor, cTelefonoRecibidor)
                                VALUES (@clienteId, @direccionId, @etiqueta, @nombreRecibidor, @telefono)";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@clienteId", clienteId));
            cmd.Parameters.Add(new MySqlParameter("@direccionId", direccionId));
            cmd.Parameters.Add(new MySqlParameter("@etiqueta", etiqueta));
            cmd.Parameters.Add(new MySqlParameter("@nombreRecibidor", nombreRecibidor));
            cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));

            await cmd.ExecuteNonQueryAsync();
        }

        private async Task InsertarTienda(MySqlCommand cmd, string nombreComercial, string descripcion, string urlLogo, string correo, string telefono, string razonSocial, int direccionId, string codigoPostal, string plan)
        {
            var planId = plan switch
            {
                "Básico" => 1,
                "Profesional" => 2,
                _ => 1
            };

            cmd.CommandText = @"INSERT INTO TTiendas (cNombreComercial, tDescripcion, cUrlLogo, cCorreoAtencion, cTelefonoAtencion, cRazonSocial, nDireccionFK, cCodigoPostal, eEstadoTienda, nPlanFK, dFechaVencimientoSuscripcion)
                                VALUES (@nombreComercial, @descripcion, @urlLogo, @correo, @telefono, @razonSocial, @direccionId, @codigoPostal, 'Pendiente', @planId, DATE_ADD(NOW(), INTERVAL 1 YEAR))";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@nombreComercial", nombreComercial));
            cmd.Parameters.Add(new MySqlParameter("@descripcion", descripcion));
            cmd.Parameters.Add(new MySqlParameter("@urlLogo", urlLogo));
            cmd.Parameters.Add(new MySqlParameter("@correo", correo));
            cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
            cmd.Parameters.Add(new MySqlParameter("@razonSocial", razonSocial));
            cmd.Parameters.Add(new MySqlParameter("@direccionId", direccionId));
            cmd.Parameters.Add(new MySqlParameter("@codigoPostal", codigoPostal));
            cmd.Parameters.Add(new MySqlParameter("@planId", planId));

            await cmd.ExecuteNonQueryAsync();
        }

        private static string BCryptPasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
