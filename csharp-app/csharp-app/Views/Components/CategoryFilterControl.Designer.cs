using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    partial class CategoryFilterControl
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2ComboBox cmbCategories;

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
            cmbCategories = new Guna2ComboBox();
            SuspendLayout();
            // 
            // cmbCategories
            // 
            cmbCategories.BackColor = Color.Transparent;
            cmbCategories.BorderColor = Color.FromArgb(220, 220, 232);
            cmbCategories.BorderRadius = 8;
            cmbCategories.CustomizableEdges = customizableEdges1;
            cmbCategories.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.FocusedColor = Color.Empty;
            cmbCategories.Font = new Font("Segoe UI", 9F);
            cmbCategories.ForeColor = Color.Black;
            cmbCategories.ItemHeight = 30;
            cmbCategories.Location = new Point(0, 0);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbCategories.Size = new Size(124, 36);
            cmbCategories.TabIndex = 0;
            cmbCategories.SelectedIndexChanged += CmbCategories_SelectedIndexChanged;
            // 
            // CategoryFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cmbCategories);
            Name = "CategoryFilter";
            Size = new Size(165, 36);
            ResumeLayout(false);
        }
    }
}