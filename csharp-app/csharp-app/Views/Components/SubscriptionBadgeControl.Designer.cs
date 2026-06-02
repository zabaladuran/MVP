namespace csharp_app.Views.Components
{
    partial class SubscriptionBadgeControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblText;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblText = new Label();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe UI", 9F);
            lblText.ForeColor = Color.FromArgb(30, 30, 50);
            lblText.Location = new Point(12, 8);
            lblText.Name = "lblText";
            lblText.Size = new Size(209, 20);
            lblText.TabIndex = 0;
            lblText.Text = "Suscripción vence: 31 dic 2025";
            lblText.Click += lblText_Click;
            // 
            // SubscriptionBadge
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblText);
            Name = "SubscriptionBadge";
            Padding = new Padding(12, 6, 12, 6);
            Size = new Size(350, 36);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}