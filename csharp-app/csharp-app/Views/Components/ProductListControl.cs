using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class ProductListControl : UserControl
    {
        private Color _borderColor = Color.FromArgb(220, 220, 232);
        private int _cornerRadius = 10;
        private Color _headerBackColor = Color.FromArgb(248, 249, 252);

        public ProductListControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public void AddProduct(ProductCardControl product)
        {
            if (product == null) return;
            product.Margin = new Padding(0, 0, 0, 6);
            product.Width = flowPanel.Width - 25; // ancho completo menos espacio del scroll
            flowPanel.Controls.Add(product);
        }

        public void ClearProducts()
        {
            flowPanel.Controls.Clear();
        }

        public FlowLayoutPanel ProductsContainer => flowPanel;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(10)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set { _headerBackColor = value; panelHeader.BackColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = GetRoundedRectangle(rect, _cornerRadius))
            using (var pen = new Pen(_borderColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}