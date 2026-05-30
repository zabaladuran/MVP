using System;

namespace csharp_app
{
    public interface ILoginView
    {
        string Nombre { get; }
        string Password { get; }
        event EventHandler LoginClick;
        void MostrarError(string mensaje);
        void CerrarFormulario();
    }
}