namespace csharp_app.Views.Components
{
    partial class SectionCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 40);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(177, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Pedidos recientes";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(110, 110, 130);
            lblSubtitle.Location = new Point(20, 60);
            lblSubtitle.MaximumSize = new Size(400, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(387, 40);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Los datos aquí mostrados corresponden únicamente a la tienda seleccionada en el selector superior.";
            lblSubtitle.Click += lblSubtitle_Click;
            // 
            // SectionCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Name = "SectionCard";
            Size = new Size(500, 100);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}