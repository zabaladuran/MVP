using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    public partial class SideBarControl : UserControl
    {

        private ContextMenuStrip menuTiendas;


        public SideBarControl()
        {
            InitializeComponent();
            btnDashboard.Click += (s, e) => { ResaltarBoton(btnDashboard); };
            btnInformacion.Click += (s, e) => { ResaltarBoton(btnInformacion); };
            btnProductos.Click += (s, e) => { ResaltarBoton(btnProductos); };
            btnTrabajadores.Click += (s, e) => { ResaltarBoton(btnTrabajadores); };
            btnPedidosNav.Click += (s, e) => { ResaltarBoton(btnPedidosNav); };
            btnTransacciones.Click += (s, e) => { ResaltarBoton(btnTransacciones); };
            btnPQRS.Click += (s, e) => { ResaltarBoton(btnPQRS); };
            btnConfiguracion.Click += (s, e) => { ResaltarBoton(btnConfiguracion); };

            ConfigurarMenuTiendas();


            lblIconoMasTiendas.Click += (s, e) => {
                menuTiendas.Show(lblIconoMasTiendas, new Point(0, lblIconoMasTiendas.Height));
            };

        }


        private void ConfigurarMenuTiendas()
        {
            menuTiendas = new ContextMenuStrip();
            menuTiendas.Items.Add("Tienda Centro", null, (s, e) => CambiarTienda("Tienda Centro"));
            menuTiendas.Items.Add("Tienda Sur", null, (s, e) => CambiarTienda("Tienda Sur"));
            // Agrega más opciones
        }

        private void CambiarTienda(string nombreTienda)
        {
            lblNombreTienda.Text = nombreTienda;
            // También actualiza el estado, ícono, etc.
            // Notifica al resto de la aplicación (por ejemplo, con un evento).
        }


        private void ResetearEstilosBotones()
        {
            var botones = new Guna2Button[] {
        btnDashboard, btnInformacion, btnProductos,
        btnTrabajadores, btnPedidosNav, btnTransacciones,
        btnPQRS, btnConfiguracion
    };

            foreach (var btn in botones)
            {
                if (btn == null) continue;
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(50, 50, 70);
                btn.BorderThickness = 0;
                // Si quieres quitar algún borde izquierdo que hayas puesto
                btn.BorderColor = Color.Transparent;
                // Opcional: restaurar el color de hover (no es necesario)
            }
        }

        private void ResaltarBoton(Guna2Button botonActivo)
        {
            ResetearEstilosBotones();

            botonActivo.FillColor = Color.FromArgb(230, 240, 255); // fondo azul suave
            botonActivo.ForeColor = Color.FromArgb(30, 80, 180);   // texto azul oscuro
                                                                   // Efecto de borde izquierdo (como indicador de selección)
            botonActivo.BorderThickness = 3;
            botonActivo.BorderColor = Color.FromArgb(30, 80, 180);
            // Aseguramos que el borde se vea en los 4 lados, pero puedes personalizarlo
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {

        }

        private void lblNombreTienda_Click(object sender, EventArgs e)
        {

        }

        private void lblSepTienda_Click(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {

        }
    }
}
