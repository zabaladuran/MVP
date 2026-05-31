namespace csharp_app.Views
{
    partial class MenuTiendaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sideBar1 = new SideBarControl();
            SuspendLayout();
            // 
            // sideBar1
            // 
            sideBar1.BackColor = Color.White;
            sideBar1.Location = new Point(12, 12);
            sideBar1.Name = "sideBar1";
            sideBar1.Size = new Size(305, 855);
            sideBar1.TabIndex = 0;
            sideBar1.Load += sideBar1_Load;
            // 
            // MenuTienda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1294, 879);
            Controls.Add(sideBar1);
            Name = "MenuTienda";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private SideBarControl sideBar1;
    }
}