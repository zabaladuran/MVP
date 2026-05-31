using Guna.UI2.WinForms;
using csharp_app.Views.Interface;

namespace csharp_app.Views
{
    public partial class LoginForm : Form, ILoginForm
    {
        // ── Paleta clara por defecto ─────────────────────────────────
        private static class Claro
        {
            public static Color Fondo = Color.FromArgb(241, 242, 250);
            public static Color Card = Color.White;
            public static Color Campo = Color.FromArgb(247, 247, 252);
            public static Color Borde = Color.FromArgb(210, 210, 230);
            public static Color Acento = Color.FromArgb(99, 102, 241);
            public static Color AcentoHover = Color.FromArgb(79, 82, 221);
            public static Color TextoPrim = Color.FromArgb(25, 25, 50);
            public static Color TextoSec = Color.FromArgb(120, 120, 150);
        }

        // ── ILoginForm ────────────────────────────────────────────
        public string Nombre => txtNombre.Text;
        public string Password => txtPassword.Text;
        public event EventHandler LoginClick;

        public LoginForm()
        {
            InitializeComponent();  // carga el Designer

            // Configuración de ventana
            Text = "";
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Claro.Fondo;

            // Arrastrar ventana sin barra de título
            MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

            // Conectar eventos del Designer al MVP
            btnLogin.Click += (s, e) => LoginClick?.Invoke(this, EventArgs.Empty);
            btnCerrar.Click += (s, e) => Application.Exit();

            AplicarTema();

            // Navegación con teclado
            txtNombre.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) txtPassword.Focus();
            };
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) LoginClick?.Invoke(this, EventArgs.Empty);
            };

            Load += (s, e) => txtNombre.Focus();
        }

        // ── Aplicar tema claro ───────────────────────────────────────
        private void AplicarTema()
        {
            BackColor = Claro.Fondo;
            panelCard.FillColor = Claro.Card;
            panelCirculo.FillColor = Claro.Acento;
            lblTitulo.ForeColor = Claro.TextoPrim;
            lblSubtitulo.ForeColor = Claro.TextoSec;
            lblUsuario.ForeColor = Claro.TextoSec;
            lblPass.ForeColor = Claro.TextoSec;

            AplicarCampo(txtNombre, Claro.Campo, Claro.Borde, Claro.TextoPrim);
            AplicarCampo(txtPassword, Claro.Campo, Claro.Borde, Claro.TextoPrim);

            btnLogin.FillColor = Claro.Acento;
            btnLogin.HoverState.FillColor = Claro.AcentoHover;

            panelCard.Invalidate();
            Invalidate();
        }

        private void AplicarCampo(Guna2TextBox campo, Color fondo, Color borde, Color texto)
        {
            campo.FillColor = fondo;
            campo.BorderColor = borde;
            campo.ForeColor = texto;
        }

        // ── ILoginForm ────────────────────────────────────────────
        public void MostrarError(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public void CerrarFormulario() => Close();

        // ── Win32 drag ────────────────────────────────────────────
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void lblIcono_Click(object sender, EventArgs e)
        {

        }

        private void lblIcono_Click_1(object sender, EventArgs e)
        {

        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}