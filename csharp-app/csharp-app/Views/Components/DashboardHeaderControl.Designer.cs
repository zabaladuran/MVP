namespace csharp_app.Views.Components
{
    partial class DashboardHeaderControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 40);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(310, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dashboard · Tienda Norte";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 32);
            label1.Name = "label1";
            label1.Size = new Size(206, 20);
            label1.TabIndex = 1;
            label1.Text = "Resumen general de la tienda";
            label1.Click += label1_Click;
            // 
            // DashboardHeader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Name = "DashboardHeader";
            Size = new Size(400, 54);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}