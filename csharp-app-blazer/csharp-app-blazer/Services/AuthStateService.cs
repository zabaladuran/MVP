using Microsoft.JSInterop;

namespace csharp_app_blazer.Services
{
    public class AuthStateService
    {
        private readonly TokenStore _tokenStore;
        private string? _token;
        private SesionUsuario? _sesion;

        public SesionUsuario? SesionActual => _sesion;
        public bool EstaAutenticado => _sesion is not null && _sesion.Expiracion > DateTime.UtcNow;

        public event Action? OnCambioEstado;

        public AuthStateService(TokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }

        public async Task IniciarSesionAsync(IJSRuntime js, LoginResultado resultado)
        {
            var sesion = new SesionUsuario
            {
                TrabajadorId = resultado.UsuarioId ?? 0,
                Nombre = resultado.Nombre ?? "",
                Correo = "",
                Expiracion = DateTime.UtcNow.AddDays(7)
            };

            _token = _tokenStore.GenerarToken(sesion);
            _sesion = sesion;

            var datos = System.Text.Json.JsonSerializer.Serialize(new
            {
                token = _token,
                expiracion = sesion.Expiracion
            });

            await js.InvokeVoidAsync("localStorage.setItem", "mvp_sesion", datos);

            NotificarCambio();
        }

        public async Task CerrarSesionAsync(IJSRuntime js)
        {
            if (_token is not null)
                _tokenStore.RemoverToken(_token);

            _token = null;
            _sesion = null;

            await js.InvokeVoidAsync("localStorage.removeItem", "mvp_sesion");

            NotificarCambio();
        }

        public async Task<bool> RestaurarSesionAsync(IJSRuntime js)
        {
            try
            {
                var datos = await js.InvokeAsync<string>("localStorage.getItem", "mvp_sesion");
                if (string.IsNullOrEmpty(datos))
                    return false;

                using var doc = System.Text.Json.JsonDocument.Parse(datos);
                var token = doc.RootElement.GetProperty("token").GetString();
                if (token is null)
                    return false;

                var sesion = _tokenStore.ValidarToken(token);
                if (sesion is null)
                {
                    await js.InvokeVoidAsync("localStorage.removeItem", "mvp_sesion");
                    return false;
                }

                _token = token;
                _sesion = sesion;
                NotificarCambio();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void NotificarCambio()
        {
            OnCambioEstado?.Invoke();
        }
    }
}
