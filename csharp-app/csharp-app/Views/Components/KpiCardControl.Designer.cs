namespace csharp_app.Views.Components
{
    partial class KpiCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblValue;
        private Label lblSub;
        private Label lblTrendIcon; // opcional: icono de tendencia (▲/▼)

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblValue = new Label();
            lblSub = new Label();
            lblTrendIcon = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 9F);
            lblTitle.ForeColor = Color.FromArgb(100, 100, 120);
            lblTitle.Location = new Point(14, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(130, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Título";
            // 
            // lblValue
            // 
            lblValue.BackColor = Color.Transparent;
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue.ForeColor = Color.FromArgb(20, 20, 30);
            lblValue.Location = new Point(12, 32);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(120, 48);
            lblValue.TabIndex = 1;
            lblValue.Text = "0";
            lblValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSub
            // 
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 8.5F);
            lblSub.ForeColor = Color.FromArgb(110, 110, 130);
            lblSub.Location = new Point(14, 80);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(130, 25);
            lblSub.TabIndex = 2;
            lblSub.Text = "pruebaaa";
            lblSub.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTrendIcon
            // 
            lblTrendIcon.BackColor = Color.Transparent;
            lblTrendIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrendIcon.ForeColor = Color.FromArgb(34, 197, 94);
            lblTrendIcon.Location = new Point(100, 80);
            lblTrendIcon.Name = "lblTrendIcon";
            lblTrendIcon.Size = new Size(30, 22);
            lblTrendIcon.TabIndex = 3;
            lblTrendIcon.Text = "▲";
            lblTrendIcon.TextAlign = ContentAlignment.MiddleLeft;
            lblTrendIcon.Visible = false;
            // 
            // KpiCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTrendIcon);
            Controls.Add(lblSub);
            Controls.Add(lblValue);
            Controls.Add(lblTitle);
            Name = "KpiCardControl";
            Size = new Size(170, 116);
            ResumeLayout(false);
        }
    }
}