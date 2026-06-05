using MySql.Data.MySqlClient;
using csharp_app_blazer.Data;

namespace csharp_app_blazer.Services
{
    public class AuthService : IAuthService
    {
        private readonly DbConnectionFactory _connectionFactory;

        public AuthService(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<LoginResultado> LoginAsync(string correo, string password)
        {
            using var conn = _connectionFactory.CreateConnection();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(
                "SELECT nTrabajadorID, cNombre, cApellido, cPassword FROM TTrabajador WHERE cCorreo = @correo",
                conn);
            cmd.Parameters.Add(new MySqlParameter("@correo", correo));

            using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                return new LoginResultado
                {
                    Exitoso = false,
                    Mensaje = "Usuario no encontrado. Verifica tu correo."
                };
            }

            var hash = reader.GetString(3);

            if (!BCrypt.Net.BCrypt.Verify(password, hash))
            {
                return new LoginResultado
                {
                    Exitoso = false,
                    Mensaje = "Contraseña incorrecta."
                };
            }

            return new LoginResultado
            {
                Exitoso = true,
                UsuarioId = reader.GetInt32(0),
                Nombre = $"{reader.GetString(1)} {reader.GetString(2)}",
                Mensaje = "Inicio de sesión exitoso."
            };
        }
    }
}
