namespace csharp_app.Views.Components
{
    partial class ProductListControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblProductoHeader;
        private System.Windows.Forms.Label lblCategoriaHeader;
        private System.Windows.Forms.Label lblPrecioHeader;
        private System.Windows.Forms.Label lblStockHeader;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblProductoHeader = new Label();
            lblCategoriaHeader = new Label();
            lblPrecioHeader = new Label();
            lblStockHeader = new Label();
            flowPanel = new FlowLayoutPanel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(248, 249, 252);
            panelHeader.Controls.Add(lblProductoHeader);
            panelHeader.Controls.Add(lblCategoriaHeader);
            panelHeader.Controls.Add(lblPrecioHeader);
            panelHeader.Controls.Add(lblStockHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 52);
            panelHeader.TabIndex = 0;
            // 
            // lblProductoHeader
            // 
            lblProductoHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductoHeader.ForeColor = Color.FromArgb(80, 80, 100);
            lblProductoHeader.Location = new Point(20, 14);
            lblProductoHeader.Name = "lblProductoHeader";
            lblProductoHeader.Size = new Size(120, 20);
            lblProductoHeader.TabIndex = 0;
            lblProductoHeader.Text = "PRODUCTO";
            lblProductoHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategoriaHeader
            // 
            lblCategoriaHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoriaHeader.ForeColor = Color.FromArgb(80, 80, 100);
            lblCategoriaHeader.Location = new Point(160, 14);
            lblCategoriaHeader.Name = "lblCategoriaHeader";
            lblCategoriaHeader.Size = new Size(120, 20);
            lblCategoriaHeader.TabIndex = 1;
            lblCategoriaHeader.Text = "CATEGORÍA";
            lblCategoriaHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrecioHeader
            // 
            lblPrecioHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecioHeader.ForeColor = Color.FromArgb(80, 80, 100);
            lblPrecioHeader.Location = new Point(340, 14);
            lblPrecioHeader.Name = "lblPrecioHeader";
            lblPrecioHeader.Size = new Size(80, 20);
            lblPrecioHeader.TabIndex = 2;
            lblPrecioHeader.Text = "PRECIO";
            lblPrecioHeader.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStockHeader
            // 
            lblStockHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStockHeader.ForeColor = Color.FromArgb(80, 80, 100);
            lblStockHeader.Location = new Point(470, 14);
            lblStockHeader.Name = "lblStockHeader";
            lblStockHeader.Size = new Size(80, 20);
            lblStockHeader.TabIndex = 3;
            lblStockHeader.Text = "STOCK";
            lblStockHeader.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowPanel
            // 
            flowPanel.AutoScroll = true;
            flowPanel.BackColor = Color.Transparent;
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.Location = new Point(0, 52);
            flowPanel.Name = "flowPanel";
            flowPanel.Padding = new Padding(8);
            flowPanel.Size = new Size(600, 398);
            flowPanel.TabIndex = 1;
            flowPanel.WrapContents = false;
            // 
            // ProductListControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(flowPanel);
            Controls.Add(panelHeader);
            Name = "ProductListControl";
            Size = new Size(600, 450);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}