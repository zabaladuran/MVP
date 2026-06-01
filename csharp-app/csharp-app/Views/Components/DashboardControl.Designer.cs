using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;
using csharp_app.Views.Components;

namespace csharp_app.Views.Components
{
    partial class DashboardControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel panelMain;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Guna2Panel panelBanner;
        private Label lblBanner;
        private Guna2Panel panelKPIs;
        private KpiCardControl cardProductos;
        private KpiCardControl cardPedidos;
        private KpiCardControl cardVentas;
        private KpiCardControl cardPQRS;
        private Guna2Panel panelOrders;
        private Label lblOrderTitle;
        private Label lblOrderSub;
        private DataGridView dgvPedidos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colFecha;

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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}
