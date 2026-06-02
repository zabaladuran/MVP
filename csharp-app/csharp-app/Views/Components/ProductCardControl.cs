using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class ProductCardControl : UserControl
    {
        private int _cornerRadius = 8;
        private Color _cardBackColor = Color.White;
        private Color _borderColor = Color.FromArgb(220, 220, 232);

        // Eventos para acciones
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        public ProductCardControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Height = 45;
            this.BackColor = Color.Transparent;

            // Suscribir eventos de botones
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        // Propiedades públicas para acceder a los labels
        [Category("Producto")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ProductName
        {
            get => lblProducto.Text;
            set => lblProducto.Text = value;
        }

        [Category("Producto")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Category
        {
            get => lblCategoria.Text;
            set => lblCategoria.Text = value;
        }

        [Category("Producto")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Price
        {
            get => lblPrecio.Text;
            set => lblPrecio.Text = value;
        }

        [Category("Producto")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Stock
        {
            get => lblStock.Text;
            set => lblStock.Text = value;
        }

        [Category("Appearance")]
        [DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color CardBackColor
        {
            get => _cardBackColor;
            set { _cardBackColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = GetRoundedRectangle(rect, _cornerRadius))
            using (var brush = new SolidBrush(_cardBackColor))
            using (var pen = new Pen(_borderColor, 1))
            {
                e.Graphics.FillPath(brush, path);
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

        private void lblStock_Click(object sender, EventArgs e)
        {

        }

        private void lblProducto_Click(object sender, EventArgs e)
        {

        }
    }
}