namespace csharp_app.Views.Components
{
    partial class ProductoControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            kpiCardControl1 = new KpiCardControl();
            kpiCardControl2 = new KpiCardControl();
            kpiCardControl3 = new KpiCardControl();
            searchBox1 = new SearchBox();
            addProductButton1 = new AddProductButton();
            categoryFilter1 = new CategoryFilter();
            categoryFilter2 = new CategoryFilter();
            productListControl1 = new ProductListControl();
            productCardControl1 = new ProductCardControl();
            SuspendLayout();
            // 
            // kpiCardControl1
            // 
            kpiCardControl1.BackColor = Color.White;
            kpiCardControl1.Location = new Point(25, 17);
            kpiCardControl1.Name = "kpiCardControl1";
            kpiCardControl1.Size = new Size(196, 128);
            kpiCardControl1.TabIndex = 0;
            // 
            // kpiCardControl2
            // 
            kpiCardControl2.BackColor = Color.White;
            kpiCardControl2.Location = new Point(270, 17);
            kpiCardControl2.Name = "kpiCardControl2";
            kpiCardControl2.Size = new Size(196, 128);
            kpiCardControl2.TabIndex = 1;
            // 
            // kpiCardControl3
            // 
            kpiCardControl3.BackColor = Color.White;
            kpiCardControl3.Location = new Point(523, 17);
            kpiCardControl3.Name = "kpiCardControl3";
            kpiCardControl3.Size = new Size(202, 128);
            kpiCardControl3.TabIndex = 2;
            // 
            // searchBox1
            // 
            searchBox1.BackColor = Color.Transparent;
            searchBox1.Location = new Point(25, 166);
            searchBox1.Name = "searchBox1";
            searchBox1.Size = new Size(172, 36);
            searchBox1.TabIndex = 3;
            // 
            // addProductButton1
            // 
            addProductButton1.BackColor = Color.Transparent;
            addProductButton1.ButtonColor = Color.FromArgb(99, 102, 241);
            addProductButton1.ButtonHoverColor = Color.FromArgb(79, 82, 221);
            addProductButton1.Location = new Point(550, 166);
            addProductButton1.Name = "addProductButton1";
            addProductButton1.Size = new Size(175, 51);
            addProductButton1.TabIndex = 4;
            // 
            // categoryFilter1
            // 
            categoryFilter1.BackColor = Color.Transparent;
            categoryFilter1.ComboDefaultText = "";
            categoryFilter1.Location = new Point(220, 166);
            categoryFilter1.Name = "categoryFilter1";
            categoryFilter1.Size = new Size(127, 36);
            categoryFilter1.TabIndex = 5;
            categoryFilter1.UseWaitCursor = true;
            // 
            // categoryFilter2
            // 
            categoryFilter2.BackColor = Color.Transparent;
            categoryFilter2.ComboDefaultText = "";
            categoryFilter2.Location = new Point(397, 166);
            categoryFilter2.Name = "categoryFilter2";
            categoryFilter2.Size = new Size(132, 36);
            categoryFilter2.TabIndex = 6;
            categoryFilter2.Load += categoryFilter2_Load;
            // 
            // productListControl1
            // 
            productListControl1.BackColor = Color.Gainsboro;
            productListControl1.BorderColor = Color.FromArgb(220, 220, 232);
            productListControl1.HeaderBackColor = Color.FromArgb(248, 249, 252);
            productListControl1.Location = new Point(25, 237);
            productListControl1.Name = "productListControl1";
            productListControl1.Size = new Size(700, 501);
            productListControl1.TabIndex = 7;
            productListControl1.Load += productListControl1_Load;
            // 
            // productCardControl1
            // 
            productCardControl1.BackColor = Color.Transparent;
            productCardControl1.BorderColor = Color.FromArgb(220, 220, 232);
            productCardControl1.CardBackColor = Color.White;
            productCardControl1.Category = "Categoría";
            productCardControl1.Location = new Point(25, 292);
            productCardControl1.Name = "productCardControl1";
            productCardControl1.Price = "$0";
            productCardControl1.ProductName = "Producto";
            productCardControl1.Size = new Size(700, 56);
            productCardControl1.Stock = "0";
            productCardControl1.TabIndex = 8;
            // 
            // ProductoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(productCardControl1);
            Controls.Add(productListControl1);
            Controls.Add(categoryFilter2);
            Controls.Add(categoryFilter1);
            Controls.Add(addProductButton1);
            Controls.Add(searchBox1);
            Controls.Add(kpiCardControl3);
            Controls.Add(kpiCardControl2);
            Controls.Add(kpiCardControl1);
            Name = "ProductoControl";
            Size = new Size(751, 750);
            ResumeLayout(false);
        }

        #endregion

        private KpiCardControl kpiCardControl1;
        private KpiCardControl kpiCardControl2;
        private KpiCardControl kpiCardControl3;
        private SearchBox searchBox1;
        private AddProductButton addProductButton1;
        private CategoryFilter categoryFilter2;
        public CategoryFilter categoryFilter1;
        private ProductListControl productListControl1;
        private ProductCardControl productCardControl1;
    }
}
