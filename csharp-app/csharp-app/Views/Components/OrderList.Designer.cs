namespace csharp_app.Views.Components
{
    partial class OrderList
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderId;
        private System.Windows.Forms.Label lblHeaderCustomer;
        private System.Windows.Forms.Label lblHeaderTotal;
        private System.Windows.Forms.Label lblHeaderStatus;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblHeaderId = new System.Windows.Forms.Label();
            lblHeaderCustomer = new System.Windows.Forms.Label();
            lblHeaderTotal = new System.Windows.Forms.Label();
            lblHeaderStatus = new System.Windows.Forms.Label();
            flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ───────────────────────────────────────────────
            panelHeader.BackColor = Color.FromArgb(248, 249, 252);
            panelHeader.Controls.Add(lblHeaderId);
            panelHeader.Controls.Add(lblHeaderCustomer);
            panelHeader.Controls.Add(lblHeaderTotal);
            panelHeader.Controls.Add(lblHeaderStatus);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 48);
            panelHeader.TabIndex = 0;

            // ── lblHeaderId ───────────────────────────────────────────────
            lblHeaderId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeaderId.ForeColor = Color.FromArgb(80, 80, 100);
            lblHeaderId.Location = new Point(16, 8);
            lblHeaderId.Name = "lblHeaderId";
            lblHeaderId.Size = new Size(90, 32);
            lblHeaderId.TabIndex = 0;
            lblHeaderId.Text = "Comprobante";
            lblHeaderId.TextAlign = ContentAlignment.MiddleLeft;

            // ── lblHeaderCustomer ─────────────────────────────────────────
            lblHeaderCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeaderCustomer.ForeColor = Color.FromArgb(80, 80, 100);
            lblHeaderCustomer.Location = new Point(114, 8);
            lblHeaderCustomer.Name = "lblHeaderCustomer";
            lblHeaderCustomer.Size = new Size(200, 32);
            lblHeaderCustomer.TabIndex = 1;
            lblHeaderCustomer.Text = "Cliente";
            lblHeaderCustomer.TextAlign = ContentAlignment.MiddleLeft;

            // ── lblHeaderTotal ────────────────────────────────────────────
            lblHeaderTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeaderTotal.ForeColor = Color.FromArgb(80, 80, 100);
            lblHeaderTotal.Location = new Point(478, 8);
            lblHeaderTotal.Name = "lblHeaderTotal";
            lblHeaderTotal.Size = new Size(90, 32);
            lblHeaderTotal.TabIndex = 2;
            lblHeaderTotal.Text = "Total";
            lblHeaderTotal.TextAlign = ContentAlignment.MiddleRight;

            // ── lblHeaderStatus ───────────────────────────────────────────
            lblHeaderStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeaderStatus.ForeColor = Color.FromArgb(80, 80, 100);
            lblHeaderStatus.Location = new Point(504, 8);
            lblHeaderStatus.Name = "lblHeaderStatus";
            lblHeaderStatus.Size = new Size(80, 32);
            lblHeaderStatus.TabIndex = 3;
            lblHeaderStatus.Text = "Estado";
            lblHeaderStatus.TextAlign = ContentAlignment.MiddleCenter;

            // ── flowPanel ─────────────────────────────────────────────────
            flowPanel.AutoScroll = true;
            flowPanel.BackColor = Color.White;
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.Name = "flowPanel";
            flowPanel.Padding = new Padding(8);
            flowPanel.Size = new Size(600, 400);
            flowPanel.TabIndex = 1;
            flowPanel.WrapContents = false;

            // ── OrderList ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flowPanel);
            Controls.Add(panelHeader);
            Name = "OrderList";
            Size = new Size(600, 448);

            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}