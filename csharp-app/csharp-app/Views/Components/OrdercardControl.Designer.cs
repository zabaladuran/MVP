namespace csharp_app.Views.Components
{
    partial class OrdercardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblId = new Label();
            lblCustomer = new Label();
            lblTotal = new Label();
            pnlStatus = new Panel();
            lblStatus = new Label();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(99, 102, 241);
            lblId.Location = new Point(22, 12);
            lblId.Name = "lblId";
            lblId.Size = new Size(78, 24);
            lblId.TabIndex = 0;
            lblId.Text = "#00000";
            lblId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustomer
            // 
            lblCustomer.Font = new Font("Segoe UI", 9F);
            lblCustomer.ForeColor = Color.FromArgb(50, 50, 70);
            lblCustomer.Location = new Point(191, 12);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(216, 24);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Cliente";
            lblCustomer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(30, 30, 40);
            lblTotal.Location = new Point(427, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(116, 24);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "$0";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Click += lblTotal_Click;
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.FromArgb(241, 245, 249);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Location = new Point(571, 12);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(80, 24);
            pnlStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(30, 41, 59);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(80, 24);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Pendiente";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Click += lblStatus_Click;
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlStatus);
            Controls.Add(lblTotal);
            Controls.Add(lblCustomer);
            Controls.Add(lblId);
            Name = "OrderCard";
            Size = new Size(666, 48);
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        public Label lblStatus;
    }
}