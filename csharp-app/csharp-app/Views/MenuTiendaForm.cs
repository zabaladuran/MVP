using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_app.Views
{
    public partial class MenuTiendaForm : Form
    {
        public MenuTiendaForm()
        {
            InitializeComponent();
            
            // Suscribirse al evento de cambio de sección
            sideBar1.SectionChanged += SideBar1_SectionChanged;
            
            // Suscribirse al evento de cambio de tienda
            sideBar1.StoreChanged += SideBar1_StoreChanged;
            
            // Mostrar solo Dashboard por defecto
            dashboardControl1.Visible = true;
            productoControl1.Visible = false;
            
            // Resaltar el botón de Dashboard por defecto
            sideBar1.HighlightDashboard();
        }

        private void SideBar1_SectionChanged(object sender, string section)
        {
            // Ocultar todos los controles
            dashboardControl1.Visible = false;
            productoControl1.Visible = false;

            // Mostrar el control correspondiente
            switch (section)
            {
                case "Dashboard":
                    dashboardControl1.Visible = true;
                    dashboardHeaderControl1.Title = "Dashboard";
                    break;
                case "Productos":
                    productoControl1.Visible = true;
                    dashboardHeaderControl1.Title = "Productos";
                    break;
                case "Informacion":
                    dashboardHeaderControl1.Title = "Información";
                    break;
                case "Trabajadores":
                    dashboardHeaderControl1.Title = "Trabajadores";
                    break;
                case "Pedidos":
                    dashboardHeaderControl1.Title = "Pedidos";
                    break;
                case "Transacciones":
                    dashboardHeaderControl1.Title = "Transacciones";
                    break;
                case "PQRS":
                    dashboardHeaderControl1.Title = "PQRS";
                    break;
                case "Configuracion":
                    dashboardHeaderControl1.Title = "Configuración";
                    break;
            }
        }

        private void SideBar1_StoreChanged(object sender, string storeName)
        {
            // Ocultar todos los controles
            dashboardControl1.Visible = false;
            productoControl1.Visible = false;

            // Mostrar el dashboard por defecto
            dashboardControl1.Visible = true;
            dashboardHeaderControl1.Title = "Dashboard";
            
            // Actualizar el nombre de la tienda
            dashboardHeaderControl1.StoreName = storeName;
            
            // Resaltar el botón de Dashboard en el sidebar
            sideBar1.HighlightDashboard();
        }

        private void sideBar1_Load(object sender, EventArgs e)
        {

        }

        private void dashboardHeaderControl1_Load(object sender, EventArgs e)
        {

        }

        private void dashboardControl1_Load(object sender, EventArgs e)
        {

        }

        private void productoControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
