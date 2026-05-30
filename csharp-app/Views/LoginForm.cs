    using System;
    using System.Drawing;
    using System.Windows.Forms;

    namespace csharp_app
    {
        public class LoginForm : Form, ILoginView
        {
            private TextBox txtNombre;
            private TextBox txtPassword;
            private Button btnLogin;

            public string Nombre => txtNombre.Text;
            public string Password => txtPassword.Text;

            public event EventHandler LoginClick;

            public LoginForm()
            {
                Text = "Login";
                Width = 300;
                Height = 180;
                StartPosition = FormStartPosition.CenterScreen;

                var lblUser = new Label { Text = "Usuario:", Left = 10, Top = 15, Width = 70 };
                txtNombre = new TextBox { Left = 90, Top = 12, Width = 170 };

                var lblPass = new Label { Text = "Contraseña:", Left = 10, Top = 50, Width = 70 };
                txtPassword = new TextBox { Left = 90, Top = 47, Width = 170, UseSystemPasswordChar = true };

                btnLogin = new Button { Text = "Ingresar", Left = 90, Top = 85, Width = 100 };
                btnLogin.Click += (s, e) => LoginClick?.Invoke(this, EventArgs.Empty);

                Controls.AddRange(new Control[] { lblUser, txtNombre, lblPass, txtPassword, btnLogin });
            }

            public void MostrarError(string mensaje)
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            public void CerrarFormulario()
            {
                Close();
            }
        }
    }