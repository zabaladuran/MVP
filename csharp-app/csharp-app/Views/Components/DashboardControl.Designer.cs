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
        private Label lblAviso;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardControl));
            kpiCardControl4 = new KpiCardControl();
            kpiCardControl1 = new KpiCardControl();
            kpiCardControl2 = new KpiCardControl();
            kpiCardControl3 = new KpiCardControl();
            infoBanner1 = new InfoBanner();
            sectionCard1 = new SectionCard();
            orderList1 = new OrderList();
            orderCard1 = new OrderCard();
            SuspendLayout();
            // 
            // kpiCardControl4
            // 
            kpiCardControl4.BackColor = Color.White;
            kpiCardControl4.Location = new Point(386, 94);
            kpiCardControl4.Name = "kpiCardControl4";
            kpiCardControl4.Size = new Size(171, 145);
            kpiCardControl4.TabIndex = 3;
            // 
            // kpiCardControl1
            // 
            kpiCardControl1.BackColor = Color.White;
            kpiCardControl1.Location = new Point(13, 94);
            kpiCardControl1.Name = "kpiCardControl1";
            kpiCardControl1.Size = new Size(171, 145);
            kpiCardControl1.TabIndex = 4;
            // 
            // kpiCardControl2
            // 
            kpiCardControl2.BackColor = Color.White;
            kpiCardControl2.Location = new Point(199, 94);
            kpiCardControl2.Name = "kpiCardControl2";
            kpiCardControl2.Size = new Size(171, 145);
            kpiCardControl2.TabIndex = 5;
            // 
            // kpiCardControl3
            // 
            kpiCardControl3.BackColor = Color.White;
            kpiCardControl3.Location = new Point(571, 94);
            kpiCardControl3.Name = "kpiCardControl3";
            kpiCardControl3.Size = new Size(171, 145);
            kpiCardControl3.TabIndex = 6;
            // 
            // infoBanner1
            // 
            infoBanner1.BackColor = Color.FromArgb(239, 246, 255);
            infoBanner1.BannerColor = Color.FromArgb(239, 246, 255);
            infoBanner1.BorderColor = Color.FromArgb(191, 219, 254);
            infoBanner1.Icon = (Image)resources.GetObject("infoBanner1.Icon");
            infoBanner1.Location = new Point(13, 15);
            infoBanner1.Name = "infoBanner1";
            infoBanner1.Padding = new Padding(8);
            infoBanner1.Size = new Size(732, 64);
            infoBanner1.TabIndex = 7;
            infoBanner1.Load += infoBanner1_Load_1;
            // 
            // sectionCard1
            // 
            sectionCard1.BackColor = Color.Transparent;
            sectionCard1.Location = new Point(13, 257);
            sectionCard1.Name = "sectionCard1";
            sectionCard1.Size = new Size(732, 135);
            sectionCard1.TabIndex = 8;
            sectionCard1.Load += sectionCard1_Load_1;
            // 
            // orderList1
            // 
            orderList1.BackColor = Color.White;
            orderList1.Location = new Point(13, 395);
            orderList1.Name = "orderList1";
            orderList1.Size = new Size(729, 367);
            orderList1.TabIndex = 9;
            // 
            // orderCard1
            // 
            orderCard1.BackColor = Color.White;
            orderCard1.Location = new Point(13, 470);
            orderCard1.Name = "orderCard1";
            orderCard1.Size = new Size(664, 60);
            orderCard1.TabIndex = 10;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(orderCard1);
            Controls.Add(orderList1);
            Controls.Add(sectionCard1);
            Controls.Add(infoBanner1);
            Controls.Add(kpiCardControl3);
            Controls.Add(kpiCardControl2);
            Controls.Add(kpiCardControl1);
            Controls.Add(kpiCardControl4);
            Name = "DashboardControl";
            Size = new Size(675, 531);
            Load += DashboardControl_Load;
            ResumeLayout(false);
        }

        #endregion
        private KpiCardControl kpiCardControl4;
        private KpiCardControl kpiCardControl5;
        private SectionCard sectionCard1;
        private KpiCardControl kpiCardControl1;
        private KpiCardControl kpiCardControl2;
        private KpiCardControl kpiCardControl3;
        private InfoBanner infoBanner1;
        private OrderList orderList1;
        private OrderCard orderCard1;
    }
}
