namespace csharp_app.Views.Components
{
    partial class InfoBannerControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picIcon = new PictureBox();
            lblMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // picIcon
            // 
            picIcon.BackColor = Color.Transparent;
            picIcon.Location = new Point(12, 13);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(24, 24);
            picIcon.TabIndex = 0;
            picIcon.TabStop = false;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 9.5F);
            lblMessage.ForeColor = Color.FromArgb(30, 30, 50);
            lblMessage.Location = new Point(44, 15);
            lblMessage.MaximumSize = new Size(400, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(133, 22);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Mensaje de información";
            // 
            // InfoBanner
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 246, 255);
            Controls.Add(lblMessage);
            Controls.Add(picIcon);
            Name = "InfoBanner";
            Padding = new Padding(8);
            Size = new Size(400, 50);
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}