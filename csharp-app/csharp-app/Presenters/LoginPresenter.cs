using System;
using csharp_app.Views.Interface;
using csharp_app.Services;
using csharp_app.Views;

namespace csharp_app.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginForm _view;
        private readonly ILoginService _service;

        public LoginPresenter(ILoginForm view, ILoginService service)
        {
            _view = view;
            _service = service;

            // Se suscribe al evento de la vista
            _view.LoginClick += OnLoginClick;
        }

        private void OnLoginClick(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Nombre) ||
                string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.MostrarError("Usuario y contraseña son obligatorios.");
                return;
            }

            bool ok = _service.Autenticar(_view.Nombre, _view.Password);

            if (ok)
            {
                _view.CerrarFormulario();
                //var main = new MenuTiendaForm();
                //main.ShowDialog();
            }
            else
                _view.MostrarError("Credenciales incorrectas.");
        }
    }

}
