using Guna.UI2.WinForms;
using System.Runtime.ConstrainedExecution;

namespace csharp_app.Views
{
    partial class SideBarControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelSidebar;
        private PictureBox picAvatar;
        private Label lblNombreUsuario;
        private Label lblRol;
        private Label lblSepTienda;
        private Guna2Panel panelTienda;
        private Label lblIconoTienda;
        private Label lblNombreTienda;
        private Label lblEstadoTienda;
        private Label lblSepGestion;
        private Label lblIconoMasTiendas;
        private Guna2Button btnDashboard;
        private Guna2Button btnInformacion;
        private Guna2Button btnProductos;
        private Guna2Button btnTrabajadores;
        private Label lblSepVentas;
        private Guna2Button btnPedidosNav;
        private Guna2Button btnTransacciones;
        private Label lblSepSoporte;
        private Guna2Button btnPQRS;
        private Guna2Button btnConfiguracion;
        private Guna2Button btnCerrar;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelSidebar = new Guna2Panel();
            picAvatar = new PictureBox();
            lblNombreUsuario = new Label();
            lblRol = new Label();
            lblSepTienda = new Label();
            panelTienda = new Guna2Panel();
            lblIconoMasTiendas = new Label();
            lblIconoTienda = new Label();
            lblNombreTienda = new Label();
            lblEstadoTienda = new Label();
            btnDashboard = new Guna2Button();
            lblSepGestion = new Label();
            btnInformacion = new Guna2Button();
            btnProductos = new Guna2Button();
            btnTrabajadores = new Guna2Button();
            lblSepVentas = new Label();
            btnPedidosNav = new Guna2Button();
            btnTransacciones = new Guna2Button();
            lblSepSoporte = new Label();
            btnPQRS = new Guna2Button();
            btnConfiguracion = new Guna2Button();
            btnCerrar = new Guna2Button();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            panelTienda.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.White;
            panelSidebar.Controls.Add(picAvatar);
            panelSidebar.Controls.Add(lblNombreUsuario);
            panelSidebar.Controls.Add(lblRol);
            panelSidebar.Controls.Add(lblSepTienda);
            panelSidebar.Controls.Add(panelTienda);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Controls.Add(lblSepGestion);
            panelSidebar.Controls.Add(btnInformacion);
            panelSidebar.Controls.Add(btnProductos);
            panelSidebar.Controls.Add(btnTrabajadores);
            panelSidebar.Controls.Add(lblSepVentas);
            panelSidebar.Controls.Add(btnPedidosNav);
            panelSidebar.Controls.Add(btnTransacciones);
            panelSidebar.Controls.Add(lblSepSoporte);
            panelSidebar.Controls.Add(btnPQRS);
            panelSidebar.Controls.Add(btnConfiguracion);
            panelSidebar.Controls.Add(btnCerrar);
            panelSidebar.CustomizableEdges = customizableEdges21;
            panelSidebar.Dock = DockStyle.Fill;
            panelSidebar.FillColor = Color.White;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Padding = new Padding(16, 20, 16, 20);
            panelSidebar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            panelSidebar.Size = new Size(302, 835);
            panelSidebar.TabIndex = 0;
            panelSidebar.Paint += panelSidebar_Paint;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(220, 218, 240);
            picAvatar.Location = new Point(16, 20);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(48, 48);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(20, 20, 30);
            lblNombreUsuario.Location = new Point(76, 22);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(106, 23);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Carlos Pérez";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 8.5F);
            lblRol.ForeColor = Color.FromArgb(110, 110, 130);
            lblRol.Location = new Point(77, 46);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(104, 20);
            lblRol.TabIndex = 2;
            lblRol.Text = "Administrador";
            // 
            // lblSepTienda
            // 
            lblSepTienda.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblSepTienda.ForeColor = Color.FromArgb(140, 140, 160);
            lblSepTienda.Location = new Point(16, 84);
            lblSepTienda.Name = "lblSepTienda";
            lblSepTienda.Size = new Size(100, 23);
            lblSepTienda.TabIndex = 3;
            lblSepTienda.Text = "TIENDA ACTIVA";
            lblSepTienda.Click += lblSepTienda_Click;
            // 
            // panelTienda
            // 
            panelTienda.BorderRadius = 10;
            panelTienda.Controls.Add(lblIconoMasTiendas);
            panelTienda.Controls.Add(lblIconoTienda);
            panelTienda.Controls.Add(lblNombreTienda);
            panelTienda.Controls.Add(lblEstadoTienda);
            panelTienda.CustomizableEdges = customizableEdges1;
            panelTienda.FillColor = Color.FromArgb(245, 244, 252);
            panelTienda.Location = new Point(16, 110);
            panelTienda.Name = "panelTienda";
            panelTienda.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelTienda.Size = new Size(260, 65);
            panelTienda.TabIndex = 4;
            // 
            // lblIconoMasTiendas
            // 
            lblIconoMasTiendas.Cursor = Cursors.Hand;
            lblIconoMasTiendas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIconoMasTiendas.ForeColor = Color.FromArgb(100, 100, 120);
            lblIconoMasTiendas.Location = new Point(220, 18);
            lblIconoMasTiendas.Name = "lblIconoMasTiendas";
            lblIconoMasTiendas.Size = new Size(21, 24);
            lblIconoMasTiendas.TabIndex = 0;
            lblIconoMasTiendas.Text = "▼";
            lblIconoMasTiendas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIconoTienda
            // 
            lblIconoTienda.Font = new Font("Segoe UI Emoji", 14F);
            lblIconoTienda.Location = new Point(12, 18);
            lblIconoTienda.Name = "lblIconoTienda";
            lblIconoTienda.Size = new Size(30, 30);
            lblIconoTienda.TabIndex = 0;
            lblIconoTienda.Text = "🏪";
            lblIconoTienda.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombreTienda
            // 
            lblNombreTienda.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNombreTienda.ForeColor = Color.FromArgb(20, 20, 30);
            lblNombreTienda.Location = new Point(48, 15);
            lblNombreTienda.Name = "lblNombreTienda";
            lblNombreTienda.Size = new Size(119, 23);
            lblNombreTienda.TabIndex = 1;
            lblNombreTienda.Text = "Tienda Norte";
            lblNombreTienda.Click += lblNombreTienda_Click;
            // 
            // lblEstadoTienda
            // 
            lblEstadoTienda.BackColor = Color.FromArgb(34, 197, 94);
            lblEstadoTienda.Font = new Font("Segoe UI", 7.2F, FontStyle.Bold);
            lblEstadoTienda.ForeColor = Color.White;
            lblEstadoTienda.Location = new Point(52, 38);
            lblEstadoTienda.Name = "lblEstadoTienda";
            lblEstadoTienda.Size = new Size(52, 18);
            lblEstadoTienda.TabIndex = 2;
            lblEstadoTienda.Text = "Activa";
            lblEstadoTienda.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            btnDashboard.BorderRadius = 8;
            btnDashboard.CustomizableEdges = customizableEdges3;
            btnDashboard.FillColor = Color.Transparent;
            btnDashboard.Font = new Font("Segoe UI", 9.8F);
            btnDashboard.ForeColor = Color.FromArgb(50, 50, 70);
            btnDashboard.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnDashboard.Location = new Point(8, 196);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDashboard.Size = new Size(150, 42);
            btnDashboard.TabIndex = 6;
            btnDashboard.Text = "📊  Dashboard";
            // 
            // lblSepGestion
            // 
            lblSepGestion.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblSepGestion.ForeColor = Color.FromArgb(140, 140, 160);
            lblSepGestion.Location = new Point(16, 252);
            lblSepGestion.Name = "lblSepGestion";
            lblSepGestion.Size = new Size(100, 23);
            lblSepGestion.TabIndex = 7;
            lblSepGestion.Text = "GESTIÓN";
            // 
            // btnInformacion
            // 
            btnInformacion.BorderRadius = 8;
            btnInformacion.CustomizableEdges = customizableEdges5;
            btnInformacion.FillColor = Color.Transparent;
            btnInformacion.Font = new Font("Segoe UI", 9.8F);
            btnInformacion.ForeColor = Color.FromArgb(50, 50, 70);
            btnInformacion.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnInformacion.Location = new Point(3, 278);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnInformacion.Size = new Size(164, 42);
            btnInformacion.TabIndex = 8;
            btnInformacion.Text = "ℹ️  Información";
            btnInformacion.Click += btnInformacion_Click;
            // 
            // btnProductos
            // 
            btnProductos.BorderRadius = 8;
            btnProductos.CustomizableEdges = customizableEdges7;
            btnProductos.FillColor = Color.Transparent;
            btnProductos.Font = new Font("Segoe UI", 9.8F);
            btnProductos.ForeColor = Color.FromArgb(50, 50, 70);
            btnProductos.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnProductos.Location = new Point(3, 322);
            btnProductos.Name = "btnProductos";
            btnProductos.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnProductos.Size = new Size(150, 42);
            btnProductos.TabIndex = 9;
            btnProductos.Text = "📦  Productos";
            btnProductos.Click += btnProductos_Click;
            // 
            // btnTrabajadores
            // 
            btnTrabajadores.BorderRadius = 8;
            btnTrabajadores.CustomizableEdges = customizableEdges9;
            btnTrabajadores.FillColor = Color.Transparent;
            btnTrabajadores.Font = new Font("Segoe UI", 9.8F);
            btnTrabajadores.ForeColor = Color.FromArgb(50, 50, 70);
            btnTrabajadores.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnTrabajadores.Location = new Point(8, 370);
            btnTrabajadores.Name = "btnTrabajadores";
            btnTrabajadores.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnTrabajadores.Size = new Size(160, 42);
            btnTrabajadores.TabIndex = 10;
            btnTrabajadores.Text = "👥  Trabajadores";
            btnTrabajadores.Click += btnTrabajadores_Click;
            // 
            // lblSepVentas
            // 
            lblSepVentas.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblSepVentas.ForeColor = Color.FromArgb(140, 140, 160);
            lblSepVentas.Location = new Point(16, 428);
            lblSepVentas.Name = "lblSepVentas";
            lblSepVentas.Size = new Size(100, 23);
            lblSepVentas.TabIndex = 11;
            lblSepVentas.Text = "VENTAS";
            // 
            // btnPedidosNav
            // 
            btnPedidosNav.BorderRadius = 8;
            btnPedidosNav.CustomizableEdges = customizableEdges11;
            btnPedidosNav.FillColor = Color.Transparent;
            btnPedidosNav.Font = new Font("Segoe UI", 9.8F);
            btnPedidosNav.ForeColor = Color.FromArgb(50, 50, 70);
            btnPedidosNav.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnPedidosNav.Location = new Point(8, 454);
            btnPedidosNav.Name = "btnPedidosNav";
            btnPedidosNav.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnPedidosNav.Size = new Size(122, 42);
            btnPedidosNav.TabIndex = 12;
            btnPedidosNav.Text = "\U0001f6d2  Pedidos";
            // 
            // btnTransacciones
            // 
            btnTransacciones.BorderRadius = 8;
            btnTransacciones.CustomizableEdges = customizableEdges13;
            btnTransacciones.FillColor = Color.Transparent;
            btnTransacciones.Font = new Font("Segoe UI", 9.8F);
            btnTransacciones.ForeColor = Color.FromArgb(50, 50, 70);
            btnTransacciones.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnTransacciones.Location = new Point(8, 502);
            btnTransacciones.Name = "btnTransacciones";
            btnTransacciones.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnTransacciones.Size = new Size(168, 42);
            btnTransacciones.TabIndex = 14;
            btnTransacciones.Text = "💰  Transacciones";
            // 
            // lblSepSoporte
            // 
            lblSepSoporte.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblSepSoporte.ForeColor = Color.FromArgb(140, 140, 160);
            lblSepSoporte.Location = new Point(16, 556);
            lblSepSoporte.Name = "lblSepSoporte";
            lblSepSoporte.Size = new Size(100, 23);
            lblSepSoporte.TabIndex = 15;
            lblSepSoporte.Text = "SOPORTE";
            // 
            // btnPQRS
            // 
            btnPQRS.BorderRadius = 8;
            btnPQRS.CustomizableEdges = customizableEdges15;
            btnPQRS.FillColor = Color.Transparent;
            btnPQRS.Font = new Font("Segoe UI", 9.8F);
            btnPQRS.ForeColor = Color.FromArgb(50, 50, 70);
            btnPQRS.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnPQRS.Location = new Point(8, 582);
            btnPQRS.Name = "btnPQRS";
            btnPQRS.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnPQRS.Size = new Size(106, 42);
            btnPQRS.TabIndex = 16;
            btnPQRS.Text = "📋  PQRS";
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.BorderRadius = 8;
            btnConfiguracion.CustomizableEdges = customizableEdges17;
            btnConfiguracion.FillColor = Color.Transparent;
            btnConfiguracion.Font = new Font("Segoe UI", 9.8F);
            btnConfiguracion.ForeColor = Color.FromArgb(50, 50, 70);
            btnConfiguracion.HoverState.FillColor = Color.FromArgb(240, 240, 250);
            btnConfiguracion.Location = new Point(7, 630);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnConfiguracion.Size = new Size(174, 42);
            btnConfiguracion.TabIndex = 18;
            btnConfiguracion.Text = "⚙️  Configuración";
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BorderRadius = 8;
            btnCerrar.CustomizableEdges = customizableEdges19;
            btnCerrar.FillColor = Color.FromArgb(250, 245, 245);
            btnCerrar.Font = new Font("Segoe UI", 9.8F);
            btnCerrar.ForeColor = Color.FromArgb(180, 60, 60);
            btnCerrar.HoverState.FillColor = Color.FromArgb(240, 230, 230);
            btnCerrar.Location = new Point(19, 770);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnCerrar.Size = new Size(260, 42);
            btnCerrar.TabIndex = 19;
            btnCerrar.Text = "🚪  Cerrar sesión";
            // 
            // SideBarControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelSidebar);
            Name = "SideBarControl";
            Size = new Size(302, 835);
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            panelTienda.ResumeLayout(false);
            ResumeLayout(false);


        }

        #endregion
    }
}
