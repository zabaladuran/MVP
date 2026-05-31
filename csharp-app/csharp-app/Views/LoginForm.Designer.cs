using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;
namespace csharp_app.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Declaración de controles
        private Guna2Panel panelCard;
        private Guna2Panel panelCirculo;
        private Guna2Panel lineaDecorativa;
        private Label lblIcono;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private Label lblPass;
        private Label lblVersion;
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelCard = new Guna2Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lineaDecorativa = new Guna2Panel();
            panelCirculo = new Guna2Panel();
            lblIcono = new Label();
            lblUsuario = new Label();
            txtNombre = new Guna2TextBox();
            lblPass = new Label();
            txtPassword = new Guna2TextBox();
            btnLogin = new Guna2Button();
            lblVersion = new Label();
            btnCerrar = new Guna2Button();
            panelCard.SuspendLayout();
            panelCirculo.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.Controls.Add(lblTitulo);
            panelCard.Controls.Add(lblSubtitulo);
            panelCard.Controls.Add(lineaDecorativa);
            panelCard.Controls.Add(panelCirculo);
            panelCard.Controls.Add(lblUsuario);
            panelCard.Controls.Add(txtNombre);
            panelCard.Controls.Add(lblPass);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnLogin);
            panelCard.Controls.Add(lblVersion);
            panelCard.CustomizableEdges = customizableEdges11;
            panelCard.FillColor = Color.White;
            panelCard.Location = new Point(50, 40);
            panelCard.Name = "panelCard";
            panelCard.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelCard.Size = new Size(420, 540);
            panelCard.TabIndex = 0;
            panelCard.Paint += panelCard_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(25, 25, 50);
            lblTitulo.Location = new Point(20, 120);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 42);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Bienvenido";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(130, 130, 165);
            lblSubtitulo.Location = new Point(20, 168);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(380, 22);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Ingresa tus credenciales para continuar";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineaDecorativa
            // 
            lineaDecorativa.CustomizableEdges = customizableEdges1;
            lineaDecorativa.FillColor = Color.FromArgb(99, 102, 241);
            lineaDecorativa.Location = new Point(185, 198);
            lineaDecorativa.Name = "lineaDecorativa";
            lineaDecorativa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            lineaDecorativa.Size = new Size(50, 3);
            lineaDecorativa.TabIndex = 3;
            // 
            // panelCirculo
            // 
            panelCirculo.Controls.Add(lblIcono);
            panelCirculo.CustomizableEdges = customizableEdges3;
            panelCirculo.FillColor = Color.FromArgb(99, 102, 241);
            panelCirculo.Location = new Point(170, 30);
            panelCirculo.Name = "panelCirculo";
            panelCirculo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelCirculo.Size = new Size(80, 80);
            panelCirculo.TabIndex = 0;
            // 
            // lblIcono
            // 
            lblIcono.BackColor = Color.Transparent;
            lblIcono.Font = new Font("Segoe UI Emoji", 26F);
            lblIcono.ForeColor = Color.White;
            lblIcono.Location = new Point(-40, 0);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(168, 90);
            lblIcono.TabIndex = 0;
            lblIcono.Text = "👤";
            lblIcono.TextAlign = ContentAlignment.MiddleCenter;
            lblIcono.Click += lblIcono_Click_1;
            // 
            // lblUsuario
            // 
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(120, 120, 150);
            lblUsuario.Location = new Point(31, 218);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(358, 18);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // txtNombre
            // 
            txtNombre.BorderColor = Color.FromArgb(210, 210, 230);
            txtNombre.CustomizableEdges = customizableEdges5;
            txtNombre.DefaultText = "";
            txtNombre.FillColor = Color.FromArgb(247, 247, 252);
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.ForeColor = Color.FromArgb(25, 25, 50);
            txtNombre.Location = new Point(31, 240);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Escribe tu usuario";
            txtNombre.SelectedText = "";
            txtNombre.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNombre.Size = new Size(358, 48);
            txtNombre.TabIndex = 5;
            // 
            // lblPass
            // 
            lblPass.BackColor = Color.Transparent;
            lblPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(120, 120, 150);
            lblPass.Location = new Point(31, 306);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(358, 18);
            lblPass.TabIndex = 6;
            lblPass.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(210, 210, 230);
            txtPassword.CustomizableEdges = customizableEdges7;
            txtPassword.DefaultText = "";
            txtPassword.FillColor = Color.FromArgb(247, 247, 252);
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(25, 25, 50);
            txtPassword.Location = new Point(31, 328);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Escribe tu contraseña";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPassword.Size = new Size(358, 48);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges9;
            btnLogin.FillColor = Color.FromArgb(99, 102, 241);
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(31, 404);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLogin.Size = new Size(358, 50);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Ingresar";
            // 
            // lblVersion
            // 
            lblVersion.BackColor = Color.Transparent;
            lblVersion.Font = new Font("Segoe UI", 8F);
            lblVersion.ForeColor = Color.FromArgb(130, 130, 165);
            lblVersion.Location = new Point(20, 500);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(380, 20);
            lblVersion.TabIndex = 9;
            lblVersion.Text = "v1.0.0 · Sistema de gestión";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            btnCerrar.CustomizableEdges = customizableEdges13;
            btnCerrar.FillColor = Color.Transparent;
            btnCerrar.Font = new Font("Segoe UI", 10F);
            btnCerrar.ForeColor = Color.FromArgb(140, 140, 170);
            btnCerrar.HoverState.FillColor = Color.FromArgb(220, 220, 220);
            btnCerrar.Location = new Point(478, 10);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnCerrar.Size = new Size(32, 32);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "✕";
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(241, 242, 250);
            ClientSize = new Size(520, 620);
            Controls.Add(panelCard);
            Controls.Add(btnCerrar);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            panelCard.ResumeLayout(false);
            panelCirculo.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}