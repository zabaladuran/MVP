using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    partial class ProductCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private Guna2Button btnEdit;
        private Guna2Button btnDelete;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblProducto = new Label();
            lblCategoria = new Label();
            lblPrecio = new Label();
            lblStock = new Label();
            btnEdit = new Guna2Button();
            btnDelete = new Guna2Button();
            SuspendLayout();
            // 
            // lblProducto
            // 
            lblProducto.Font = new Font("Segoe UI", 9F);
            lblProducto.ForeColor = Color.FromArgb(30, 30, 40);
            lblProducto.Location = new Point(17, 15);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(120, 20);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto";
            lblProducto.TextAlign = ContentAlignment.MiddleLeft;
            lblProducto.Click += lblProducto_Click;
            // 
            // lblCategoria
            // 
            lblCategoria.Font = new Font("Segoe UI", 9F);
            lblCategoria.ForeColor = Color.FromArgb(80, 80, 100);
            lblCategoria.Location = new Point(159, 15);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(122, 20);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoría";
            lblCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrecio
            // 
            lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.FromArgb(99, 102, 241);
            lblPrecio.Location = new Point(322, 15);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(80, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "$0";
            lblPrecio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStock
            // 
            lblStock.Font = new Font("Segoe UI", 9F);
            lblStock.ForeColor = Color.FromArgb(50, 50, 70);
            lblStock.Location = new Point(434, 15);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(80, 20);
            lblStock.TabIndex = 3;
            lblStock.Text = "0";
            lblStock.TextAlign = ContentAlignment.MiddleRight;
            lblStock.Click += lblStock_Click;
            // 
            // btnEdit
            // 
            btnEdit.BorderRadius = 6;
            btnEdit.CustomizableEdges = customizableEdges1;
            btnEdit.FillColor = Color.FromArgb(59, 130, 246);
            btnEdit.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.IndicateFocus = true;
            btnEdit.Location = new Point(538, 9);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEdit.Size = new Size(60, 26);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Editar";
            // 
            // btnDelete
            // 
            btnDelete.BorderRadius = 6;
            btnDelete.CustomizableEdges = customizableEdges3;
            btnDelete.FillColor = Color.FromArgb(239, 68, 68);
            btnDelete.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.IndicateFocus = true;
            btnDelete.Location = new Point(622, 9);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDelete.Size = new Size(60, 26);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Eliminar";
            // 
            // ProductCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(lblStock);
            Controls.Add(lblPrecio);
            Controls.Add(lblCategoria);
            Controls.Add(lblProducto);
            Name = "ProductCardControl";
            Size = new Size(695, 45);
            ResumeLayout(false);
        }
    }
}