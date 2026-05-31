namespace csharp_app.Views
{
    partial class TimerInicio
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelMain = new Guna.UI2.WinForms.Guna2Panel();
            lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.BorderRadius = 30;
            panelMain.Controls.Add(lblTitulo);
            panelMain.Controls.Add(lblStatus);
            panelMain.Controls.Add(progressBar);
            panelMain.CustomizableEdges = customizableEdges1;
            panelMain.FillColor = System.Drawing.Color.White;
            panelMain.Location = new System.Drawing.Point(40, 30);
            panelMain.Name = "panelMain";
            panelMain.ShadowDecoration.BorderRadius = 30;
            panelMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            panelMain.ShadowDecoration.Enabled = true;
            panelMain.Size = new System.Drawing.Size(440, 300);
            panelMain.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = System.Drawing.Color.Transparent;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(25, 25, 50);
            lblTitulo.Location = new System.Drawing.Point(40, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(361, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bienvenido a la aplicación";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = System.Drawing.Color.Transparent;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(120, 120, 150);
            lblStatus.Location = new System.Drawing.Point(40, 110);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(177, 25);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Cargando aplicación...";
            // 
            // progressBar
            // 
            progressBar.CustomizableEdges = customizableEdges2;
            progressBar.FillColor = System.Drawing.Color.FromArgb(236, 239, 255);
            progressBar.ForeColor = System.Drawing.Color.White;
            progressBar.Location = new System.Drawing.Point(40, 160);
            progressBar.Name = "progressBar";
            progressBar.ProgressColor = System.Drawing.Color.FromArgb(99, 102, 241);
            progressBar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            progressBar.Size = new System.Drawing.Size(360, 20);
            progressBar.TabIndex = 2;
            progressBar.Text = "guna2ProgressBar1";
            progressBar.Value = 0;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // TimerInicio
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 242, 250);
            ClientSize = new System.Drawing.Size(520, 360);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TimerInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimerInicio";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
