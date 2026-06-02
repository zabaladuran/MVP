using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace csharp_app.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private Guna2Panel panelCard;
        private Guna2Panel panelCirculo;
        private Guna2Panel lineaDecorativa;
        private Label lblIcono;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private Label lblPass;
        private Label lblVersion;
        private Label lblRegistrarse;   // ← nuevo
        private Guna2TextBox txtNombre;
        private Guna2TextBox txtPassword;
        private Guna2Button btnLogin;
        private Guna2Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelCard = new Guna2Panel();
            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();
            this.lineaDecorativa = new Guna2Panel();
            this.panelCirculo = new Guna2Panel();
            this.lblIcono = new Label();
            this.lblUsuario = new Label();
            this.txtNombre = new Guna2TextBox();
            this.lblPass = new Label();
            this.txtPassword = new Guna2TextBox();
            this.btnLogin = new Guna2Button();
            this.lblVersion = new Label();
            this.lblRegistrarse = new Label();   // ← nuevo
            this.btnCerrar = new Guna2Button();
            this.panelCard.SuspendLayout();
            this.panelCirculo.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelCard
            // 
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.lineaDecorativa);
            this.panelCard.Controls.Add(this.panelCirculo);
            this.panelCard.Controls.Add(this.lblUsuario);
            this.panelCard.Controls.Add(this.txtNombre);
            this.panelCard.Controls.Add(this.lblPass);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Controls.Add(this.lblRegistrarse);   // ← nuevo
            this.panelCard.Controls.Add(this.lblVersion);
            this.panelCard.FillColor = Color.White;
            this.panelCard.Location = new Point(50, 40);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new Size(420, 560);   // altura aumentada de 540 a 560
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new PaintEventHandler(this.panelCard_Paint);

            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = Color.Transparent;
            this.lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(25, 25, 50);
            this.lblTitulo.Location = new Point(20, 120);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(380, 42);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Bienvenido";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.BackColor = Color.Transparent;
            this.lblSubtitulo.Font = new Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = Color.FromArgb(130, 130, 165);
            this.lblSubtitulo.Location = new Point(20, 168);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new Size(380, 22);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Ingresa tus credenciales para continuar";
            this.lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lineaDecorativa
            // 
            this.lineaDecorativa.FillColor = Color.FromArgb(99, 102, 241);
            this.lineaDecorativa.Location = new Point(185, 198);
            this.lineaDecorativa.Name = "lineaDecorativa";
            this.lineaDecorativa.Size = new Size(50, 3);
            this.lineaDecorativa.TabIndex = 3;

            // 
            // panelCirculo
            // 
            this.panelCirculo.Controls.Add(this.lblIcono);
            this.panelCirculo.FillColor = Color.FromArgb(99, 102, 241);
            this.panelCirculo.Location = new Point(170, 30);
            this.panelCirculo.Name = "panelCirculo";
            this.panelCirculo.Size = new Size(80, 80);
            this.panelCirculo.TabIndex = 0;

            // 
            // lblIcono
            // 
            this.lblIcono.BackColor = Color.Transparent;
            this.lblIcono.Font = new Font("Segoe UI Emoji", 26F);
            this.lblIcono.ForeColor = Color.White;
            this.lblIcono.Location = new Point(-40, 0);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Size = new Size(168, 90);
            this.lblIcono.TabIndex = 0;
            this.lblIcono.Text = "👤";
            this.lblIcono.TextAlign = ContentAlignment.MiddleCenter;
            this.lblIcono.Click += new EventHandler(this.lblIcono_Click_1);

            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = Color.Transparent;
            this.lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblUsuario.ForeColor = Color.FromArgb(120, 120, 150);
            this.lblUsuario.Location = new Point(31, 218);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(358, 18);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";

            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = Color.FromArgb(210, 210, 230);
            this.txtNombre.DefaultText = "";
            this.txtNombre.FillColor = Color.FromArgb(247, 247, 252);
            this.txtNombre.Font = new Font("Segoe UI", 11F);
            this.txtNombre.ForeColor = Color.FromArgb(25, 25, 50);
            this.txtNombre.Location = new Point(31, 240);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Escribe tu usuario";
            this.txtNombre.Size = new Size(358, 48);
            this.txtNombre.TabIndex = 5;

            // 
            // lblPass
            // 
            this.lblPass.BackColor = Color.Transparent;
            this.lblPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPass.ForeColor = Color.FromArgb(120, 120, 150);
            this.lblPass.Location = new Point(31, 306);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new Size(358, 18);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Contraseña";

            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = Color.FromArgb(210, 210, 230);
            this.txtPassword.DefaultText = "";
            this.txtPassword.FillColor = Color.FromArgb(247, 247, 252);
            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = Color.FromArgb(25, 25, 50);
            this.txtPassword.Location = new Point(31, 328);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "Escribe tu contraseña";
            this.txtPassword.Size = new Size(358, 48);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // btnLogin
            // 
            this.btnLogin.FillColor = Color.FromArgb(99, 102, 241);
            this.btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(31, 404);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(358, 50);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Ingresar";

            // 
            // lblRegistrarse (nuevo)
            // 
            this.lblRegistrarse.BackColor = Color.Transparent;
            this.lblRegistrarse.Font = new Font("Segoe UI", 9F);
            this.lblRegistrarse.ForeColor = Color.FromArgb(99, 102, 241);
            this.lblRegistrarse.Location = new Point(20, 470);
            this.lblRegistrarse.Name = "lblRegistrarse";
            this.lblRegistrarse.Size = new Size(380, 22);
            this.lblRegistrarse.TabIndex = 10;
            this.lblRegistrarse.Text = "¿No tienes cuenta? Regístrate aquí";
            this.lblRegistrarse.TextAlign = ContentAlignment.MiddleCenter;
            this.lblRegistrarse.Cursor = Cursors.Hand;

            // 
            // lblVersion (ajustada posición)
            // 
            this.lblVersion.BackColor = Color.Transparent;
            this.lblVersion.Font = new Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = Color.FromArgb(130, 130, 165);
            this.lblVersion.Location = new Point(20, 510);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new Size(380, 20);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "v1.0.0 · Sistema de gestión";
            this.lblVersion.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnCerrar
            // 
            this.btnCerrar.FillColor = Color.Transparent;
            this.btnCerrar.Font = new Font("Segoe UI", 10F);
            this.btnCerrar.ForeColor = Color.FromArgb(140, 140, 170);
            this.btnCerrar.HoverState.FillColor = Color.FromArgb(220, 220, 220);
            this.btnCerrar.Location = new Point(478, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(32, 32);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "✕";

            // 
            // LoginForm
            // 
            this.BackColor = Color.FromArgb(241, 242, 250);
            this.ClientSize = new Size(520, 620);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.btnCerrar);
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panelCard.ResumeLayout(false);
            this.panelCirculo.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}