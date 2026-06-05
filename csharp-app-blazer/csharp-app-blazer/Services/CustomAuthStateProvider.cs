using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace csharp_app_blazer.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly AuthStateService _authState;

        public CustomAuthStateProvider(AuthStateService authState)
        {
            _authState = authState;
            _authState.OnCambioEstado += () =>
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_authState.EstaAutenticado && _authState.SesionActual is not null)
            {
                var s = _authState.SesionActual;
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, s.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, s.TrabajadorId.ToString()),
                    new Claim(ClaimTypes.Email, s.Correo),
                }, "mvp_auth");

                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
            }

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }
    }
}
