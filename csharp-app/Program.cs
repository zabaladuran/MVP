using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_app
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new LoginForm();

            // 2. Crear el servicio
            var servicio = new UsuarioService();

            // 3. Crear el Presenter pasándole los dos anteriores
            var presenter = new LoginPresenter(form, servicio);

            Application.Run(form);

        }
    }
}
