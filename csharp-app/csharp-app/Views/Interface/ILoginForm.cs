using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_app.Views.Interface
{
    public interface ILoginForm
    {
        string Nombre { get; }
        string Password { get; }
        event EventHandler LoginClick;
        void MostrarError(string mensaje);
        void CerrarFormulario();
    }
}
