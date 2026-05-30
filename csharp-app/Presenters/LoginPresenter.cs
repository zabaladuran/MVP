using System;

namespace csharp_app
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IUsuarioService _service;

        public LoginPresenter(ILoginView view, IUsuarioService service)
        {
            _view = view;
            _service = service;

            // Se suscribe al evento de la vista
            _view.LoginClick += OnLoginClick;
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Nombre) ||
                string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.MostrarError("Usuario y contraseña son obligatorios.");
                return;
            }

            bool ok = _service.Autenticar(_view.Nombre, _view.Password);

            if (ok)
                _view.CerrarFormulario();
            else
                _view.MostrarError("Credenciales incorrectas.");
        }
    }

}
