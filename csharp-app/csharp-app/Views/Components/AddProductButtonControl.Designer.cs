using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    partial class AddProductButtonControl
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Button btnAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAdd = new Guna2Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 8;
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FillColor = Color.FromArgb(128, 128, 255);
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.HoverState.FillColor = Color.FromArgb(79, 82, 221);
            btnAdd.Location = new Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(140, 62);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Nuevo producto";
            btnAdd.Click += BtnAdd_Click;
            // 
            // AddProductButton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnAdd);
            Name = "AddProductButton";
            Size = new Size(140, 62);
            ResumeLayout(false);
        }
    }
}