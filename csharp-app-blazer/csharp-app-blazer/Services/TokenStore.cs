using System.Collections.Concurrent;

namespace csharp_app_blazer.Services
{
    public class TokenStore
    {
        private readonly ConcurrentDictionary<string, SesionUsuario> _sesiones = new();

        public string GenerarToken(SesionUsuario sesion)
        {
            var token = Guid.NewGuid().ToString("N");
            _sesiones[token] = sesion;
            return token;
        }

        public SesionUsuario? ValidarToken(string token)
        {
            if (_sesiones.TryGetValue(token, out var sesion))
            {
                if (sesion.Expiracion > DateTime.UtcNow)
                    return sesion;

                _sesiones.TryRemove(token, out _);
            }
            return null;
        }

        public void RemoverToken(string token)
        {
            _sesiones.TryRemove(token, out _);
        }
    }
}
