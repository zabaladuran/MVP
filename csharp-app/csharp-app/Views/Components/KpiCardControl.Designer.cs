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
            this.lblTitle = new Label();
            this.lblValue = new Label();
            this.lblSub = new Label();
            this.lblTrendIcon = new Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 9F);
            this.lblTitle.ForeColor = Color.FromArgb(100, 100, 120);
            this.lblTitle.Location = new Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(100, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Título";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = false;
            this.lblValue.BackColor = Color.Transparent;
            this.lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblValue.ForeColor = Color.FromArgb(20, 20, 30);
            this.lblValue.Location = new Point(12, 32);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new Size(120, 48);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "0";
            this.lblValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = false;
            this.lblSub.BackColor = Color.Transparent;
            this.lblSub.Font = new Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = Color.FromArgb(110, 110, 130);
            this.lblSub.Location = new Point(14, 80);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new Size(130, 22);
            this.lblSub.TabIndex = 2;
            this.lblSub.Text = "pruebaaa";
            this.lblSub.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTrendIcon (opcional para mostrar ▲ o ▼)
            // 
            this.lblTrendIcon.AutoSize = false;
            this.lblTrendIcon.BackColor = Color.Transparent;
            this.lblTrendIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTrendIcon.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblTrendIcon.Location = new Point(100, 80);
            this.lblTrendIcon.Name = "lblTrendIcon";
            this.lblTrendIcon.Size = new Size(30, 22);
            this.lblTrendIcon.TabIndex = 3;
            this.lblTrendIcon.Text = "▲";
            this.lblTrendIcon.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTrendIcon.Visible = false; // invisible por defecto
            // 
            // KpiCardControl
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.lblTrendIcon);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblTitle);
            this.Name = "KpiCardControl";
            this.Size = new Size(170, 110); // tamaño estándar de tarjeta KPI
            this.ResumeLayout(false);
        }
    }
}